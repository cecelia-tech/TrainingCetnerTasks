using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace MonitoringApp
{
    public class Monitoring
    {
        public Settings? MonitoringSettings { get; set; }
        public Monitoring()
        {
            var JsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("WebsiteSettings.json"));

            MonitoringSettings = JsonSettings?.ToObject<Settings>();
        }
        public void StartRunningTimers()
        {
            

            foreach (var url in MonitoringSettings?.Sites)
            {
               // var aTimer = new System.Timers.Timer(2000);

                
                //Task mewTask = Task.Run(() => SendRequest(url));
                //Task.Delay(2000);

            }
            Timer timer = new Timer(SendRequest, "https://www.bbc.com/", 0, 3000);
            //timer.Dispose();
        }

        public void S(object? _)
        {
            SendRequest(_).ConfigureAwait(false);
        }
        public async void PrintProgressAsync (object? _)
        {
            await Task.Delay(200);
            Console.WriteLine("Doing more stuff");
        }

        public async void SendRequest(Object? url)
        {
            try
            {
                Console.WriteLine("Doing more stuff");
                HttpClient client = new HttpClient();
                client.Timeout = TimeSpan.FromSeconds(1);

                //var stopWatch = Stopwatch.StartNew();

                var response = await client.GetAsync((string?)url).ConfigureAwait(false);

                //stopWatch.Stop();

            //    var timeForResponse = stopWatch.Elapsed;

            //    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

            //    await CheckStatus(response.IsSuccessStatusCode, timeForResponse);

            //    Console.WriteLine("End of SendRequest");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            

        }

        public async Task CheckStatus(bool webResponse, TimeSpan timeForResponse)
        {
            if (webResponse && 
                timeForResponse <= MonitoringSettings?.ResponceTime
                )
            {
                Console.WriteLine("writing to the log");
                Console.WriteLine($"{timeForResponse.Milliseconds},");
            }
            else
            {
                await SendEmail();
                Console.WriteLine("After await SendEmail");
            }

            Console.WriteLine("End of CheckStatus");
        }

        public async Task  SendEmail()
        {
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