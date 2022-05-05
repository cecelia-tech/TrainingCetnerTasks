using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Configuration;
using log4net;
using System.Xml.Linq;

namespace Monitor
{
    public class WebMonitoring
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebMonitoring));
        public TimeSpan? CheckInterval { get; set; }
        public TimeSpan? ResponseTime { get; set; }
        public string? Site { get; set; }
        public string? Title { get; set; }
        public string? Email { get; set; }
        public string? FileToWatchPath { get; set; }
        public System.Timers.Timer? ATimer { get; set; }
        public HttpClient? Client { get; set; }
       // public FileSystemWatcher Watcher { get; set; }
        public CancellationToken Token { get; set; }


        public WebMonitoring(string checkInterval, string responseTime, string site, string email, string filePathToWatch, string title)
        {
            CheckInterval = TimeSpan.Parse(checkInterval);
            ResponseTime = TimeSpan.Parse(responseTime);
            Site = site;
            Email = email;
            FileToWatchPath = filePathToWatch;
            Title = title;
        }

        public void StartSiteMonitoring(object token)
        {
            Token = (CancellationToken)token;

                ATimer = new System.Timers.Timer()
                {
                    AutoReset = true,
                    Enabled = true,
                    Interval = CheckInterval.Value.TotalMilliseconds
                };

                ATimer.Elapsed += async (obj, e) => await OnTimedEvent();
        }

        //public void WatchFile()
        //{
        //    Watcher = new FileSystemWatcher
        //    {
        //        Path = FileToWatchPath,
        //        Filter = "App.config"
        //    };

        //    Watcher.NotifyFilter = NotifyFilters.LastWrite
        //                        | NotifyFilters.Size;

        //    Watcher.Changed += CancellProcess;
        //    Watcher.Deleted += CancellProcess;
        //    Watcher.Renamed += CancellProcess;

        //    Watcher.EnableRaisingEvents = true;
        //}

        //public void CancellProcess(object sender, FileSystemEventArgs e)
        //{
        //    TokenSource.Cancel();
        //    log.Error("file has been changed");
        //}

        private async Task OnTimedEvent()
        {
            if (Token.IsCancellationRequested)
            {
                ATimer?.Stop();
            }

            Client = new HttpClient();

            HttpResponseMessage response = new HttpResponseMessage();

            var stopWatch = Stopwatch.StartNew();

            response = await Client.GetAsync(Site);

            stopWatch.Stop();

            var timeForResponse = stopWatch.Elapsed;

            await CheckStatus(response.IsSuccessStatusCode, timeForResponse);
        }

        public async Task CheckStatus(bool webResponse, TimeSpan timeForResponse)
        {
            if (webResponse &&
                timeForResponse <= ResponseTime
                )
            {
                log.Error(Title);
            }
            else
            {
                await SendEmail();
            }
        }

        public async Task SendEmail()
        {
           // await Mail.SendMessage();
            await Task.Delay(500);
            Console.WriteLine("we are on the SendEmail");
            Console.WriteLine(Title);
        }
    }
}