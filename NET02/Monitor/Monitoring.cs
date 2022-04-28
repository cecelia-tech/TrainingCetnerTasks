using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Configuration;
using log4net;
using log4net.Config;


namespace Monitor
{
    public class Monitoring
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Monitoring));

        public TimeSpan? CheckInterval { get; set; }
        public TimeSpan? ResponseTime { get; set; }
        public string? Site { get; set; }
        public string? Email { get; set; }
        public string? FileToWatchPath { get; set; }
        public System.Timers.Timer? aTimer { get; set; }
        public HttpClient? Client { get; set; }
        public CancellationTokenSource TokenSource { get; set; } = new CancellationTokenSource(); 

        public Monitoring()
        {
            //var JsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("WebsiteSettings.json"));

            //MonitoringSettings = JsonSettings?.ToObject<Settings>();

            CheckInterval = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("CheckInterval"));
            ResponseTime = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("ResponceTime"));
            Site = ConfigurationManager.AppSettings.Get("Site");
            Email = ConfigurationManager.AppSettings.Get("Email");
            FileToWatchPath = ConfigurationManager.AppSettings.Get("Path");
        }

        public void SetTimer()
        {

            //cia susikursim cancellation token
            //ir persiduot ta token i method OnChengedEvent
            //galimai sita ikist i try catch
            //butinai dadet finaly su TokenSource.Dispose();
            //o gal sitas turi but if'e tel cancellation token
            WatchFile();
            try
            {
                var token = TokenSource.Token;
                aTimer = new System.Timers.Timer(CheckInterval.Value.TotalMilliseconds);
                if (!TokenSource.Token.IsCancellationRequested)
                {
                    aTimer.Elapsed += async (obj, e) => await OnTimedEvent();
                    aTimer.AutoReset = true;
                    aTimer.Enabled = true;
                }
                else
                {
                    aTimer.AutoReset = false;
                    aTimer.Enabled = false;
                };

                //aTimer.Start();
                GC.KeepAlive(aTimer);
               
            }
            catch (Exception e)
            {
                log.Error(e.Message, e);
            }
            
        }

        private async Task OnTimedEvent()
        {
            Client = new HttpClient();
            var stopWatch = new Stopwatch();
            HttpResponseMessage response = new HttpResponseMessage();

            stopWatch = Stopwatch.StartNew();
            response = await Client.GetAsync(Site);
            stopWatch.Stop();

            var timeForResponse = stopWatch.Elapsed;
            await CheckStatus(response.IsSuccessStatusCode, timeForResponse, response.Content);
        }

        public async Task CheckStatus(bool webResponse, TimeSpan timeForResponse, HttpContent url)
        {
            if (webResponse &&
                timeForResponse <= ResponseTime
                )
            {
                log.Error("changed");

               // log.Fatal("Fatal ERROR settings file has been deleted");
            }
            else
            {
                await SendEmail();
            }
        }



        public async Task SendEmail()
        {
            await Task.Delay(500);
            Console.WriteLine("we are on the SendEmail");
            //sitas metodas turi but ASYNK AWAIT for sure   
        }






        //sita darysim veliau
        public void WatchFile()
        {
            var watcher = new FileSystemWatcher
            {
                Path = FileToWatchPath,
                Filter = "App.config"
            };
            
                watcher.Changed += CancellProcess;
                watcher.Deleted += NotifyOnFileDeletion;
                watcher.Renamed += CancellProcess;

                watcher.EnableRaisingEvents = true;
                //Console.ReadLine();

                watcher.EnableRaisingEvents = false;
            
        }

        public void CancellProcess(object sender, FileSystemEventArgs e)
        {
            log.Error("file has been changed");
            TokenSource.Cancel();
        }
        public void NotifyOnFileDeletion(object sender, FileSystemEventArgs e)
        {

            log.Fatal("Fatal ERROR settings file has been deleted");
            TokenSource.Cancel();
        }
    }
}