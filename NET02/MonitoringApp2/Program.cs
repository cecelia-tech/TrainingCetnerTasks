using log4net;
using System.Configuration;
using System.Collections.Specialized;
using Monitor;
using log4net.Config;

[assembly: XmlConfigurator(Watch = true)]

//sitas tik paprastam kas ateina is jau esamu settings
//BasicConfigurator.Configure();
//sitas jeigu turim savo pasirase kazka custom
XmlConfigurator.Configure();

using (var mutex = new Mutex(false, "SingletonApp"))
{
    // TimeSpan.Zero to test the mutex's signal state and
    // return immediately without blocking
    bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
    if (isAnotherInstanceOpen)
    {
        Console.WriteLine("Only one instance of this app is allowed.");
        Thread.Sleep(2000);
        return;
    }

    Monitoring mon = new Monitoring();
    mon.SetTimer();

    //Mail.SendMessage();

    Console.ReadKey();

    mutex.ReleaseMutex();
}
