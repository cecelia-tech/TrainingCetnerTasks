using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Task02._3
{
    [Serializable]
    public class LoadJsonFile
    {
        //public List<string> AssembleyNames { get; set; } = new List<string>();
        public LoadJsonFile()
        {
            
        }
        /*public void AddAssembly(string assemblyName)
        {
            if (assemblyName is not null)
            {
                AssembleyNames.Add(assemblyName);
            }
        }

        public void GenerateJsonFile()
        {
            using (var fs = File.Create($"appsettins.json"))
            {
                JsonSerializer.Serialize(fs, AssembleyNames, new JsonSerializerOptions { WriteIndented = true });
            }
        }*/

        public List<string> GetAssembleyNames()
        {
            return JsonSerializer.Deserialize<List<string>>(File.ReadAllText("appsettins.json"));
        }

    }
}
