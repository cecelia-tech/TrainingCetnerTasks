using log4net;
using System.Configuration;
using System.Collections.Specialized;
using Monitor;
using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]

XmlConfigurator.Configure();

using (var mutex = new Mutex(false, "SingletonApp"))
{
    bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
    if (isAnotherInstanceOpen)
    {
        Console.WriteLine("Only one instance of this app is allowed.");
        Thread.Sleep(2000);
        return;
    }

    WebMonitoring mon = new WebMonitoring();
    mon.StartSiteMonitoring();

    mutex.ReleaseMutex();
}
