using ListenerInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextListener
{
    public class ListenText : IListener
    {
        public Config? settings { get; set; }

        public ListenText()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("TextListenerConfig.json"));

            settings = allJsonSettings?["ListenText"]?.ToObject<Config>();
        }

        public void Log(string message)
        {
            Console.WriteLine(message + " from Lidten text");
            Console.WriteLine(settings?.FileName);
        }

        public void Write(string message)
        {
            if (message != null)
            {
                if (File.Exists(settings?.FileName))
                {
                    using (StreamWriter file = new(settings?.FileName, append : true))
                    {
                        file.WriteLine(message);
                    }
                }
                else
                {
                    File.WriteAllText(settings?.FileName, message);
                }
            }
            
            
        }
    }
}
