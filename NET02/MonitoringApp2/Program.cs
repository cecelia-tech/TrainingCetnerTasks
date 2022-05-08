using log4net;
using System.Configuration;
using System.Collections.Specialized;
using Monitor;
using log4net.Config;
using MonitoringApp2;
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

    string path = "C:\\Users\\VitaGriciute\\source\\repos\\TrainingCetnerTasks\\NET02\\MonitoringApp2\\bin\\Debug\\net6.0";

    CancellationTokenSource tokenSource = new CancellationTokenSource();

    var token = tokenSource.Token;

    using FileSystemWatcher watcher = new FileSystemWatcher
    {
        //directory get current
        Path = path,
        Filter = "MonitoringApp2.dll.config"
    };

    watcher.NotifyFilter = NotifyFilters.Attributes |
    NotifyFilters.CreationTime |
    NotifyFilters.FileName |
    NotifyFilters.LastAccess |
    NotifyFilters.LastWrite |
    NotifyFilters.Size |
    NotifyFilters.Security;

    watcher.Changed += CancellProcess;

    watcher.EnableRaisingEvents = true;

    void CancellProcess(object sender, FileSystemEventArgs e)
    {
        tokenSource.Cancel();
        Console.WriteLine("Process has been cancelled");
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
    //var settings = WebMonitorings();

    void RunChecks()
    {
        var settings = WebMonitorings();

        foreach (var website in settings)
        {
            //try
            //{
                var task = Task.Run (async () =>
                {
                    while (!token.IsCancellationRequested)
                    {
                        await website.OnTimedEvent();

                        await Task.Delay(website.CheckInterval);

                        //token.ThrowIfCancellationRequested();
                    }
                }, token);

             //Console.WriteLine(task.Status);

            //if (token.IsCancellationRequested)
            //{
            //    //Task.Delay(1000);
            //    //task.Wait();
            //    Console.WriteLine("BREAK");
            //    //break;
            //}
        }
    }



    RunChecks();

    while (true)
    {
        if (token.IsCancellationRequested)
        {
            await Task.Delay(2000);
            tokenSource.Dispose();
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;
            await Task.Delay(4000);
            RunChecks();
        }
        else
        {
            continue;
        }

    }
        mutex.ReleaseMutex();
}
