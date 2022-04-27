using Monitor;

using (var mutex = new Mutex(false, "SingletonApp"))
{
    // TimeSpan.Zero to test the mutex's signal state and
    // return immediately without blocking
    bool isAnotherInstanceOpen = !mutex.WaitOne(TimeSpan.Zero);
    if (isAnotherInstanceOpen)
    {
        Console.WriteLine("Only one instance of this app is allowed.");
        //Console.Read();
        Thread.Sleep(2000);
        return;
    }

    Monitoring mon = new Monitoring();
    //Monitoring mon = new Monitoring();
    //mon.SetTimer();

    Console.ReadKey();

    mutex.ReleaseMutex();
}