using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace MonitoringApp
{
    public class Monitoring
    {
        public Settings? MonitoringSettings { get; set; }
        public System.Timers.Timer? aTimer { get; set; }
        HttpClient? client;
        public Monitoring()
        {
            var JsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("WebsiteSettings.json"));

            MonitoringSettings = JsonSettings?.ToObject<Settings>();
        }

        public void SetTimer()
        {
            aTimer = new System.Timers.Timer(1000);
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
            await CheckStatus(response.IsSuccessStatusCode, timeForResponse);
        }

        public async Task CheckStatus(bool webResponse, TimeSpan timeForResponse)
        {
            if (webResponse &&
                timeForResponse <= MonitoringSettings?.ResponceTime
                )
            {
                Console.WriteLine("writing to the log");
            }
            else
            {
                await SendEmail();
            }
        }

       

        public async Task  SendEmail()
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