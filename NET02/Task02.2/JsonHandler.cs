using System.Text.Json;

namespace Task02._2
{
    public class JsonHandler : IRepository
    {
        //when calling this method, write only the main directory name where all json files exists,
        //since they are saved in the different directories
        public List<User> GetUsers(string jsonPath)
        {
            if (!Directory.Exists(jsonPath))
            {
                throw new Exception("There is no data to read.");
            }

            List<User> users = new List<User>();

            foreach (var directory in Directory.EnumerateDirectories(jsonPath))
            {
                string jsonString = File.ReadAllText(directory + "\\appsettings.json");

                users.Add(JsonSerializer.Deserialize<User>(jsonString));
            }
            return users;
        }

        public void SaveUsers(List<User> users)
        {
            foreach (var user in users)
            {
                CreateDirectory($"Config\\{user.Name}");

                using (var fs = File.Create($"Config\\{user.Name}\\appsettings.json"))
                {
                    User correctedUser = new User(user.Name);
                    correctedUser.WindowSettings = user.WindowSettings.Select(window => window.GetCorrectedWindowSettings()).ToList();

                    JsonSerializer.Serialize(fs, correctedUser, new JsonSerializerOptions { WriteIndented = true });
                }
            }
        }

        void CreateDirectory(string folderTitle)
        {
            if (!Directory.Exists(folderTitle))
            {
                Directory.CreateDirectory(folderTitle);
            }
        }
    }
}
