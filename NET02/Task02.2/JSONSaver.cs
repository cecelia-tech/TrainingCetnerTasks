using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Task02._2
{
    internal class JSONSaver : IRepository
    {
        public List<User> GetUsers(string jsonPath)
        {
            if (!Directory.Exists("Config"))
            {
                throw new Exception("There is no data to read.");
            }

            List<User> users = new List<User>();

            foreach (var directory in Directory.EnumerateDirectories("Config"))
            {
                string jsonString = File.ReadAllText(directory + "\\appsettings.json");

                users.Add(JsonSerializer.Deserialize<User>(jsonString));
            }

            return users;
        }

        public void SaveUsers(string xmlPath)
        {
            XMLLoader loadUsers = new XMLLoader();

            List<User> users = loadUsers.GetUsers(xmlPath);

            foreach (var user in users)
            {
                CreateDirectory($"Config\\{user.Name}");

                using (var fs = File.Create($"Config\\{user.Name}\\appsettins.json"))
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
