using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Task02._2
{
    internal class XMLLoader : IRepository
    {
        public List<User> GetUsersFromXML(string xmlDocument)
        {
            //read and parse xml, but the task is to return the list of users
            List<User> users = new List<User>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (Stream reader = new FileStream(xmlDocument, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                users = (List<User>)serializer.Deserialize(reader);
            }
            //after parse xml and add user to the list
            //create user like List<WindowSettings>
            return users;
        }

        public void Read()
        {
            XElement userInfo = XElement.Load("Config\\newFile.xml");
            //var users = userInfo.Elements("User");

            foreach (var user in userInfo.Elements("User"))
            {
                StringBuilder infoToPrint = new StringBuilder();

                infoToPrint.Append($"Login: {user.Name} \n");

                if (CountUserMain(user) == 1)
                {
                    foreach (var window in user.Elements())
                    {
                        infoToPrint.Append($"\t{window.Value}");

                        var elements = window.Descendants();
                        //(elements.Any(x => x.Name == "left") != false ? elements.First(x => x.Name == "left").Value : '?') iskelt i atskira metoda
                        infoToPrint.Append($"({(elements.Any(x => x.Name == "Top") != false ? elements.First(x => x.Name == "Top").Value : '?') }," +
                            $"{(elements.Any(x => x.Name == "Left") != false ? elements.First(x => x.Name == "Left").Value : '?') }," +
                            $"{(elements.Any(x => x.Name == "Width") != false ? elements.First(x => x.Name == "Width").Value : '?') }," +
                            $"{(elements.Any(x => x.Name == "Height") != false ? elements.First(x => x.Name == "Height").Value : '?') }" +
                            $")\n");
                    }
                }
                Console.WriteLine(infoToPrint.ToString()); 
            }
        }
        public int CountUserMain(XElement user)
        {
            return user.Elements("window").Where(window => window.Attribute("title")?.Value == "main").Count();
        }
        public void Write(List<User> users)
        {
            //CreateDirectory("Config");

            XmlSerializer writer = new XmlSerializer(typeof(List<User>));

            //string path = Directory.GetCurrentDirectory();

            //string filePath = Path.Combine(path, "Config");

            //File.SetAttributes(filePath,
            //            (new FileInfo(filePath)).Attributes | FileAttributes.Normal);
            //FileStream stream = new FileStream("newFile.xml", FileMode.OpenOrCreate)
            //FileStream stream = File.Create(filePath)
            using (FileStream stream = new FileStream("Config\\newFile.xml", FileMode.OpenOrCreate))
            {
                writer.Serialize(stream, users);
            }
        }

        internal void CreateDirectory(string folderTitle)
        {
            if (!Directory.Exists(folderTitle))
            {
                Directory.CreateDirectory(folderTitle);
            }
        }
    }
}
