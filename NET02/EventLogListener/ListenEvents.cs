using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02._3;

namespace EventLogListener
{
    internal class ListenEvents : IListener
    {
        public Config? settings { get; set; }

        public ListenEvents()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("ConfigData.json"));

            settings = allJsonSettings?["ListenEvents"]?.ToObject<Config>();
        }
        public void Log(string message)
        {
            Console.WriteLine(message + " from listen events");
            Console.WriteLine(settings?.FileName);
        }
    }
}
