using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Text.Json;
using Task02._3;

Logger logger = new Logger();



//LoadJsonFile loadJsonFile = new LoadJsonFile();

//var assembliesLoaded = loadJsonFile.GetAssembleyNames();

//List<IListener> listeners = new List<IListener>();

//foreach (var assemblyToLoad in assembliesLoaded)
//{
//    var assembly = Assembly.LoadFrom(assemblyToLoad);
    
//    var types = assembly.GetTypes();

//    foreach (var type in types)
//    {
//        if (type.GetInterface("IListener") is not null)
//        {
//            IListener listener = (IListener)Activator.CreateInstance(type)!;
//            listeners.Add(listener);
//            listener.Log("yyyyyyy");
//            listener.Log("hhhhh");
//            Console.WriteLine(listener.settings.FileName);
//        }
//    }
//}

//var dynamicJson = JsonConvert.DeserializeObject<JObject> (File.ReadAllText("ConfigData.json"));

//JsonDocument configurations = JsonDocument.Parse("ConfigData.json"); 


   // string settings = File.ReadAllText("ConfigData.json");
    //List<string> deserializedSettings = JsonSerializer.Deserialize<List<string>>(settings).ToList()!;

//foreach (var setting in deserializedSettings)
//{
//    Console.WriteLine(setting);
//}

