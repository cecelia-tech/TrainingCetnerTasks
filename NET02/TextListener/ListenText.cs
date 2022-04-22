using ListenerInterface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TextListener
{
    public class ListenText : IListener
    {
        public Config? settings { get; set; }

        public ListenText()
        {
            var allJsonSettings = JsonConvert.DeserializeObject<JObject>(File.ReadAllText("TextListenerConfig.json"));

            settings = allJsonSettings?["TextListener"]?.ToObject<Config>();
        }

        public void Log(string message)
        {
            Console.WriteLine(message + " from Lidten text");
            Console.WriteLine(settings?.FileName);
        }

        public void Write(string message, int logLevel)
        {
            if (logLevel >= settings?.LogLevel)
            {
                if (message != null)
                {
                    if (File.Exists(settings?.FileName))
                    {
                        using (StreamWriter file = new(settings?.FileName, append: true))
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
}
