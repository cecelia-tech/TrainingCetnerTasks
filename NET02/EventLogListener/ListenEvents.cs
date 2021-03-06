using ListenerInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;


namespace EventLogListener
{
    public class ListenEvents : IListener
    {
        public Config? settings { get; set; }

        public ListenEvents()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("EventLogConfig.json"));

            settings = allJsonSettings?["EventLogListener"]?.ToObject<Config>();
        }

        public void Write(string message, int logLevel)
        {
            if (message != null && logLevel >= settings?.LogLevel)
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
                using (EventLog eventLog = new EventLog())
                {
                    eventLog.Source = settings?.SourceName;

                    //write information we need
                    eventLog.WriteEntry(message);
                }
            }
        }
    }
}
