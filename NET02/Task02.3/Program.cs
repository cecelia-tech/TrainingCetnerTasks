using MonitoringApp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json;
using Task02._3;



using (var mutex = new Mutex(false, "SingletonApp"))
{
    // TimeSpan.Zero to test the mutex's signal state and
    // return immediately without blocking
    bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
    if (isAnotherInstanceOpen)
    {
        Console.WriteLine("Only one instance of this app is allowed.");
        //Console.Read();
        //Thread.Sleep(2000);
        return;
    }

    // main application entry point
    //Logger logger = new Logger();

    //Example e = new Example();

    //logger.Track(e);
    Monitoring mon = new Monitoring();
    mon.StartRunningTimers();
    //Thread.Sleep(1000);
    Console.WriteLine("doing something else");
    Console.ReadKey();
    mutex.ReleaseMutex();
}

//const string appName = "MyAppName";
//    bool createdNew;
// Mutex mutex;

//mutex = new Mutex(true, appName, out createdNew);

//    if (!createdNew)
//    {
//        Console.WriteLine(appName + " is already running! Exiting the application.");
//        Console.ReadKey();
//        return;
//    }

//    Console.WriteLine("Continuing with the application");
//    Console.ReadKey();


//Logger logger = new Logger();

//Example e = new Example();

//logger.Track(e);
//Console.ReadKey();


