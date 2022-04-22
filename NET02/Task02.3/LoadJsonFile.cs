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
        public LoadJsonFile() { }
        public List<string> GetAssembleyNames()
        {
            return JsonSerializer.Deserialize<List<string>>(File.ReadAllText("appsettins.json"));
        }

    }
}
