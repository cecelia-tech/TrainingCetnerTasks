using System.Text.Json;

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
