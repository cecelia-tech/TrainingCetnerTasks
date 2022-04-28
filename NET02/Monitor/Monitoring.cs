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
        //public Settings? MonitoringSettings { get; set; }
        public int? CheckInterval { get; set; }
        public int? ResponseTime { get; set; }
        public string? Site { get; set; }
        public string? Email { get; set; }
        public string? FileToWatchPath { get; set; }
        public System.Timers.Timer? aTimer { get; set; }
        HttpClient? client;
        public Monitoring()
        {
            //var JsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("WebsiteSettings.json"));

            //MonitoringSettings = JsonSettings?.ToObject<Settings>();

            CheckInterval = int.Parse(ConfigurationManager.AppSettings.Get("CheckInterval"));
            ResponseTime = int.Parse(ConfigurationManager.AppSettings.Get("ResponceTime"));
            Site = ConfigurationManager.AppSettings.Get("Site");
            Email = ConfigurationManager.AppSettings.Get("Email");
            FileToWatchPath = ConfigurationManager.AppSettings.Get("Path");
        }

        public void SetTimer()
        {
            //sitas veikia
            //string sAttr;
            //sAttr = ConfigurationManager.AppSettings.Get("Key0");
            //Console.WriteLine("The value of Key0 is " + sAttr);

            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += async (obj, e) => await OnTimedEvent();
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            //aTimer.Start();
            GC.KeepAlive(aTimer);
        }

        private async Task OnTimedEvent()
        {
            client = new HttpClient();
            var stopWatch = new Stopwatch();
            HttpResponseMessage response = new HttpResponseMessage();

            foreach (var url in MonitoringSettings?.Sites)
            {
                stopWatch = Stopwatch.StartNew();
                response = await client.GetAsync(url);
                stopWatch.Stop();
            }


            var timeForResponse = stopWatch.Elapsed;
            await CheckStatus(response.IsSuccessStatusCode, timeForResponse, response.Content);
        }

        public async Task CheckStatus(bool webResponse, TimeSpan timeForResponse, HttpContent url)
        {
            if (webResponse &&
                timeForResponse <= MonitoringSettings?.ResponceTime
                )
            {
                //possibly this one is in the wrong place
                BasicConfigurator.Configure();
                //log.Info("Request was successfull");
                log.Error("changed");
                //log.Fatal("fhvbfjkd");
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
            using (var watcher = new FileSystemWatcher
            {
                Path = MonitoringSettings?.Path,
                Filter = "WebsiteSettings.json"
            })
            {
                //NEED TO THINK ABOUT DIFFERENT METHODS HOW IT WILL REACT TO THE CHANGES
                //watcher.Changed += someEvent;
                //watcher.Created += someEvent;
                //watcher.Deleted += someEvent;
                //watcher.Renamed += someEvent;
                //watcher.Error += someEvent;

                //watcher.EnableRaisingEvents = true;
                //Console.ReadLine();

                //watcher.EnableRaisingEvents = false;
            }
        }
    }
}