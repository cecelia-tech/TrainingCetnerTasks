using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Configuration;
using log4net;


namespace Monitor
{
    public class WebMonitoring
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(WebMonitoring));

        public TimeSpan? CheckInterval { get; set; }
        public TimeSpan? ResponseTime { get; set; }
        public string? Site { get; set; }
        public string? Email { get; set; }
        public string? FileToWatchPath { get; set; }
        public System.Timers.Timer? ATimer { get; set; }
        public HttpClient? Client { get; set; }
        public CancellationTokenSource TokenSource { get; set; } = new CancellationTokenSource();
        public FileSystemWatcher Watcher { get; set; }

        public WebMonitoring()
        {
            CheckInterval = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("CheckInterval"));
            ResponseTime = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("ResponceTime"));
            Site = ConfigurationManager.AppSettings.Get("Site");
            Email = ConfigurationManager.AppSettings.Get("Email");
            FileToWatchPath = ConfigurationManager.AppSettings.Get("Path");
        }

        public void StartSiteMonitoring()
        {
            try
            {
                WatchFile();

                ATimer = new System.Timers.Timer()
                {
                    AutoReset = true,
                    Enabled = true,
                    Interval = CheckInterval.Value.TotalMilliseconds
                };

                ATimer.Elapsed += async (obj, e) => await OnTimedEvent();

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ATimer?.Dispose();
                Client?.Dispose();
                TokenSource.Dispose();
                Watcher.Dispose();
            }
        }

        public void WatchFile()
        {
            Watcher = new FileSystemWatcher
            {
                Path = FileToWatchPath,
                Filter = "App.config"
            };

            Watcher.NotifyFilter = NotifyFilters.LastWrite
                                | NotifyFilters.Size;

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

        private async Task OnTimedEvent()
        {
            var token = TokenSource.Token;

            if (token.IsCancellationRequested)
            {
                ATimer? .Stop();
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
           // await Mail.SendMessage();
            await Task.Delay(500);
            Console.WriteLine("we are on the SendEmail");
        }
    }
}