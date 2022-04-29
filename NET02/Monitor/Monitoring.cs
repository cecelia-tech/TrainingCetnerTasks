using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Configuration;
using log4net;


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
            CheckInterval = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("CheckInterval"));
            ResponseTime = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("ResponceTime"));
            Site = ConfigurationManager.AppSettings.Get("Site");
            Email = ConfigurationManager.AppSettings.Get("Email");
            FileToWatchPath = ConfigurationManager.AppSettings.Get("Path");
        }

        public void SetTimer()
        {
            WatchFile();
            //try
            //{
                aTimer = new System.Timers.Timer() 
                {   AutoReset = true, 
                    Enabled = true, 
                    Interval = CheckInterval.Value.TotalMilliseconds
                };

                aTimer.Elapsed += async (obj, e) => await OnTimedEvent();

                //if (token.IsCancellationRequested)
                //{
                //    //aTimer.Elapsed += async (obj, e) => await OnTimedEvent();
                //    //aTimer.AutoReset = true;
                //    //aTimer.Enabled = true;
                //    aTimer.Stop();
                //}
                //else
                //{
                //    aTimer.Stop();
                //    //aTimer.AutoReset = false;
                //    //aTimer.Enabled = false;
                //};

                //aTimer.Start();
                //GC.KeepAlive(aTimer);
               
            //}
            //catch (Exception e)
            //{
              //  log.Error(e.Message, e);
            //}
            
        }

        private async Task OnTimedEvent()
        {

            var token = TokenSource.Token;
            if (token.IsCancellationRequested)
            {
                aTimer.Stop();
            }
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
                log.Error("Successfull, writing a log");
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


        public void WatchFile()
        {
            //dispose negalima cia
           var Watcher = new FileSystemWatcher
            {
                Path = FileToWatchPath,
                Filter = "App.config"
            };

                Watcher.Changed += CancellProcess;
                Watcher.Deleted += NotifyOnFileDeletion;
                Watcher.Renamed += CancellProcess;

                Watcher.EnableRaisingEvents = true;
        }

        public void CancellProcess(object sender, FileSystemEventArgs e)
        {
            TokenSource.Cancel();
            log.Error("file has been changed");
        }
        public void NotifyOnFileDeletion(object sender, FileSystemEventArgs e)
        {

            log.Fatal("Fatal ERROR settings file has been deleted");
            TokenSource.Cancel();
        }
    }
}