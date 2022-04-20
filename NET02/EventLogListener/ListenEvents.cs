using ListenerInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EventLogListener 
{
    public class ListenEvents : IListener
    {
        public Config? settings { get; set; }

        public ListenEvents()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("EventLogConfig.json"));

            settings = allJsonSettings?["ListenEvents"]?.ToObject<Config>();
        }
        public void Log(string message)
        {
            Console.WriteLine(message + " from listen events");
        }

        public void Write(string message)
        {
            if (message != null)
            {
                //creating a source if it doesn't exist already
                if (!EventLog.SourceExists(settings?.SourceName))
                {
                    //We can't use used immediately after creating it.
                    //Neet to run application second time to use it,
                    //That's why we return after creating SOURCE
                    EventLog.CreateEventSource(settings?.SourceName, settings?.LogName);
                    return;
                }
                //Creating eventLog instance and assigning the source
                EventLog eventLog = new EventLog();
                eventLog.Source = settings?.SourceName;

                //write information we need
                eventLog.WriteEntry(message);
            }
        }
    }
}
