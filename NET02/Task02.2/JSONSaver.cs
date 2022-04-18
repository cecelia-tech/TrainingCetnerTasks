using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace Task02._2
{
    [Serializable]
    internal class JSONSaver : IRepository
    {
        public string XmlPath { get; set; }
        public JSONSaver(string xmlPath)
        {
            XmlPath = xmlPath ?? throw new ArgumentNullException(nameof(xmlPath));
        }


        //will return list of users
        public void Read(string xmlPath)
        {
            throw new NotImplementedException();
        }

        public void SaveUsers()
        {
            XMLLoader loadUsers = new XMLLoader();

            List<User> users = loadUsers.GetUsersFromXML(XmlPath);

            foreach (var user in users)
            {
                User correctedUser = new User(user.Name);
                correctedUser.WindowSettings = user.WindowSettings.Select(window => window.GetCorrectedWindowSettings()).ToList();
                
                CreateDirectory($"Config\\{user.Name}");

                using (var fs = File.Create($"Config\\{user.Name}\\appsettins.json"))
                {
                    JsonSerializer.Serialize(fs, correctedUser, new JsonSerializerOptions { WriteIndented = true });
                }
            }
            
        }

        public void Write(List<User> users)
        {
            throw new NotImplementedException();
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
