using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Task02._2
{
    public class XMLHandler : IRepository
    {
        public List<User> GetUsers(string pathToData)
        {
            XElement usersInXML = XElement.Load(pathToData);
            List<User> users = new List<User>();

            foreach (var userNode in usersInXML.Elements("login"))
            {
                User user = new User(userNode.Attribute("name")!.Value);

                foreach (var window in userNode.Elements("window"))
                {
                    user.AddWindowSettings(new WindowSettings(window.Attribute("title")!.Value,
                        window.Element("top")?.Value is null ? null : int.Parse(window.Element("top")!.Value),
                        window.Element("left")?.Value is null ? null : int.Parse(window.Element("left")!.Value),
                        window.Element("width")?.Value is null ? null : int.Parse(window.Element("width")!.Value),
                        window.Element("height")?.Value is null ? null : int.Parse(window.Element("height")!.Value)
                        ));
                }
                users.Add(user);
            }
            return users;
        }

        public void SaveUsers(List<User> users)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

            CreateDirectory("Config");

            using (XmlWriter writer = XmlWriter.Create("Config\\writerSample.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("config");

                foreach (var user in users)
                {
                    writer.WriteStartElement("login");
                    writer.WriteAttributeString("name", user.Name);
                    foreach (var window in user.WindowSettings)
                    {
                        writer.WriteStartElement("window");
                        writer.WriteAttributeString("title", window.Title);

                        if (window.Top is not null)
                        {
                            writer.WriteStartElement("top");
                            writer.WriteValue(window.Top);
                            writer.WriteEndElement();
                        }

                        if (window.Left is not null)
                        {
                            writer.WriteStartElement("left");
                            writer.WriteValue(window.Left);
                            writer.WriteEndElement();
                        }

                        if (window.Width is not null)
                        {
                            writer.WriteStartElement("width");
                            writer.WriteValue(window.Width);
                            writer.WriteEndElement();
                        }

                        if (window.Height is not null)
                        {
                            writer.WriteStartElement("height");
                            writer.WriteValue(window.Height);
                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();   //end window
                    }

                    writer.WriteEndElement();  // end user
                }
                writer.WriteEndElement();    //ends config
                writer.WriteEndDocument();
            }
        }

        public string GetXmlInfoForDisplay(string path)
        {
            XElement userInfo = XElement.Load(path);

            StringBuilder infoToPrint = new StringBuilder();

            foreach (var user in userInfo.Elements("login"))
            {
                infoToPrint.Append($"{(IsLoginCorrect(user) == true ? "Correct" : "Incorrect")} \n");
                infoToPrint.Append($"Login: {user.Attribute("name")?.Value} \n");
                
                foreach (var window in user.Elements("window"))
                {
                    infoToPrint.Append($"\t{window.Attribute("title")?.Value}");

                    var windowNode = window.Descendants();

                    infoToPrint.Append($"({(windowNode.Any(x => x.Name == "top") != false ? windowNode.First(x => x.Name == "top").Value : '?') }," +
                        $"{(windowNode.Any(x => x.Name == "left") != false ? windowNode.First(x => x.Name == "left").Value : '?') }," +
                        $"{(windowNode.Any(x => x.Name == "width") != false ? windowNode.First(x => x.Name == "width").Value : '?') }," +
                        $"{(windowNode.Any(x => x.Name == "height") != false ? windowNode.First(x => x.Name == "height").Value : '?') }" +
                        $")\n");
                }
            }
            return infoToPrint.ToString();
        }

        private bool IsLoginCorrect(XElement user)
        {
            return CountUserMain(user) == 1 &&
                (CountElementsInMainWindow(user) == 4 ||
                CountElementsInMainWindow(user) == 0);
        }

        private int CountUserMain(XElement user)
        {
            return user.Elements("window").Where(window => window.Attribute("title")?.Value == "main").Count();
        }

        private int CountElementsInMainWindow(XElement user)
        {
            return user.Elements("window").Where(window => window.Attribute("title")?.Value == "main").Descendants().Count();
        }

        private void CreateDirectory(string folderTitle)
        {
            if (!Directory.Exists(folderTitle))
            {
                Directory.CreateDirectory(folderTitle);
            }
        }
    }
}
