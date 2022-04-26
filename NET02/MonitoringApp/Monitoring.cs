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
                //timer starts the method in a new thread   so how many sites that many threads??
                Timer timer = new Timer(SendRequest, url, 1000, 2000);

                //

            }
        }

        public async void SendRequest(Object url)
        {
            HttpClient client = new HttpClient();

            //HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create((string)url);
            

            var stopWatch = Stopwatch.StartNew();

            //using network, therefore supposed to be await
            // HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();
            HttpResponseMessage response = await client.GetAsync((string)url);

            response.IsSuccessStatusCode;

            stopWatch.Stop();

            var timeForResponse = stopWatch.Elapsed;

            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

           await CheckStatus(response.IsSuccessStatusCode, timeForResponse);

            webResponse.Close();

            Console.WriteLine("Does it ever come here?");
        }

        public async Task CheckStatus(bool webResponse, TimeSpan timeForResponse)
        {
            if (webResponse.StatusCode == HttpStatusCode.OK && 
                timeForResponse >= MonitoringSettings?.ResponceTime
                )
            {
                Console.WriteLine("making the log");
                Console.WriteLine($"{timeForResponse.Milliseconds},");
            }
            else
            {
                Console.WriteLine(await SendEmail());
            }

            Console.WriteLine("Possibly doing something else");
        }

        public async Task<string> SendEmail()
        {
            //HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create("https://docs.microsoft.com/en-us/dotnet/csharp/");

            //using network, therefore await
            //HttpWebResponse webResponse2 = (HttpWebResponse) await webRequest2.GetResponseAsync();
            //Console.WriteLine($"Should be before printing response {webResponse2.StatusDescription}");
            Console.WriteLine("Printing after responce");
            // 
            //string s = webResponse2.StatusDescription;
            //webResponse2.Close();
            return s;

            //
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