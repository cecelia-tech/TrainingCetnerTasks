using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02._3;

namespace TextListener
{
    public class ListenText : IListener
    {
        public Config? settings { get; set; }

        public ListenText()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("ConfigData.json"));

            settings = allJsonSettings?["ListenText"]?.ToObject<Config>();

        }

        public void Log(string message)
        {
            Console.WriteLine(message + " from Lidten text");
            Console.WriteLine(settings?.FileName);
        }
    }
}
