using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task02._3;

namespace WordListener
{
    public class ListenWords : IListener
    {
        public Config? settings { get; set; }

        public ListenWords()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("ConfigData.json"));

            settings = allJsonSettings?["ListenWords"]?.ToObject<Config>();
        }

        public void Log(string message)
        {
            Console.WriteLine(message + " from word listener");
            //Console.WriteLine(settings?.FileName);
        }
    }
}
