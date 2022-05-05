using log4net;
using System.Configuration;
using System.Collections.Specialized;
using Monitor;
using log4net.Config;
using MonitoringApp2;
using MonitoringApp2.WebSitesConfiguration;

[assembly: XmlConfigurator(Watch = true)]

XmlConfigurator.Configure();

//mano cancellation token turi but cia
//taip pat ir filewatcher, nes taip nukillinsiu visus vienu metu
//atcancellint threada o ne timeri??
using (var mutex = new Mutex(false, "MonitoringApp"))
{
    bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
    if (isAnotherInstanceOpen)
    {
        Console.WriteLine("Only one instance of this app is allowed.");
        Thread.Sleep(2000);
        return;
    }

    string path = "C:\\Users\\VitaGriciute\\source\\repos\\TrainingCetnerTasks\\NET02\\MonitoringApp2";

    CancellationTokenSource tokenSource = new CancellationTokenSource();

    FileSystemWatcher watcher = new FileSystemWatcher
    {
        Path = path,
        Filter = "App.config"
    };

    watcher.NotifyFilter = NotifyFilters.LastWrite
                       | NotifyFilters.Size;

    watcher.Changed += CancellProcess;
    watcher.Deleted += CancellProcess;
    watcher.Renamed += CancellProcess;

    watcher.EnableRaisingEvents = true;

    void CancellProcess(object sender, FileSystemEventArgs e)
    {
        tokenSource.Cancel();
        Console.WriteLine("Process has been cancelled");
        //log.Error("file has been changed");
    }

    var webconfig = (WebsitesConfig)ConfigurationManager.GetSection("webSettings");

    foreach (WebsitesInstanceElement website in webconfig.Websites)
    {
        WebMonitoring siteMonitoring = new WebMonitoring(
            website.CheckInterval,
            website.ResponceTime,
            website.Site,
            website.Email,
            website.Path,
            website.Title);

       // ThreadPool.QueueUserWorkItem(new WaitCallback(siteMonitoring.StartSiteMonitoring), tokenSource.Token);
        new Thread(siteMonitoring.StartSiteMonitoring).Start(tokenSource.Token);
    }

    
    
    Console.ReadKey();
    mutex.ReleaseMutex();
}
