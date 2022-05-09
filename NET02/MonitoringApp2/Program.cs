using System.Configuration;
using Monitor;
using log4net.Config;
using MonitoringApp2.WebSitesConfiguration;

[assembly: XmlConfigurator(Watch = true)]

XmlConfigurator.Configure();

using (var mutex = new Mutex(false, "MonitoringApp"))
{
    bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
    if (isAnotherInstanceOpen)
    {
        Console.WriteLine("Only one instance of this app is allowed.");
        Thread.Sleep(2000);
        return;
    }

    CancellationTokenSource tokenSource = new CancellationTokenSource();

    using FileSystemWatcher watcher = new FileSystemWatcher
    {
        Path = Directory.GetCurrentDirectory(),
        Filter = "MonitoringApp2.dll.config"
    };

    watcher.NotifyFilter = NotifyFilters.Attributes |
    NotifyFilters.CreationTime |
    NotifyFilters.FileName |
    NotifyFilters.LastAccess |
    NotifyFilters.LastWrite |
    NotifyFilters.Size |
    NotifyFilters.Security;

    watcher.Changed += RestartProcess;

    watcher.EnableRaisingEvents = true;

    void RestartProcess(object sender, FileSystemEventArgs e)
    {
        tokenSource.Cancel();

        tokenSource.Dispose();
        tokenSource = new CancellationTokenSource();

        RunChecks(tokenSource.Token);
    }

    RunChecks(tokenSource.Token);

    void RunChecks(CancellationToken token)
    {
        var settings = WebMonitorings();

        foreach (var website in settings)
        {
            var task = Task.Run(async () =>
            {
                while (!token.IsCancellationRequested)
                {
                    await website.OnTimedEvent();

                    await Task.Delay(website.CheckInterval, token);
                }

                website.Dispose();

            }, token);
        }
    }

    List<WebMonitoring> WebMonitorings()
    {
        List<WebMonitoring> webMonitorings = new List<WebMonitoring>();

        ConfigurationManager.RefreshSection("webSettings");

        var webconfig = (WebsitesConfig)ConfigurationManager.GetSection("webSettings");

        foreach (WebsitesInstanceElement website in webconfig.Websites)
        {
            webMonitorings.Add(new WebMonitoring(
                website.CheckInterval,
                website.ResponceTime,
                website.Site,
                website.Email,
                website.Title));
        }

        return webMonitorings;
    }

    await Task.Delay(TimeSpan.FromDays(1));

    mutex.ReleaseMutex();
}
