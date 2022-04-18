using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Task02._2
{
    internal class XMLLoader : IRepository
    {
        public List<User> GetUsersFromXML(string xmlDocument)
        {
            XElement usersInXML = XElement.Load(xmlDocument);
            List<User> users = new List<User>();

            foreach (var userInFile in usersInXML.Elements("login"))
            {
                User user = new User(userInFile.Attribute("name")!.Value);
                foreach (var window in userInFile.Elements("window"))
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

            // load xml file
            //usersInXML.Load(@"C:\project\aaa.xml");

            //read and parse xml, but the task is to return the list of users
            //List<User> users = new List<User>();
            //XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            //using (Stream reader = new FileStream("Config\\writerSample.xml", FileMode.Open))
            //{
            //    // Call the Deserialize method to restore the object's state.
            //    users = (List<User>)serializer.Deserialize(reader);
            //}
            //after parse xml and add user to the list
            //create user like List<WindowSettings>
            return users;
        }

        public void Read(string xmlPath)
        {
            XElement userInfo = XElement.Load(xmlPath);

            foreach (var user in userInfo.Elements("login"))
            {
                StringBuilder infoToPrint = new StringBuilder();

                infoToPrint.Append($"{(IsLoginCorrect(user) == true ? "Correct" : "Incorrect")} \n");
                infoToPrint.Append($"Login: {user.Attribute("name")?.Value} \n");
                
                foreach (var window in user.Elements("window"))
                {
                    infoToPrint.Append($"\t{window.Attribute("title")?.Value}");

                    var elements = window.Descendants();
                    //(elements.Any(x => x.Name == "left") != false ? elements.First(x => x.Name == "left").Value : '?') iskelt i atskira metoda
                    infoToPrint.Append($"({(elements.Any(x => x.Name == "top") != false ? elements.First(x => x.Name == "top").Value : '?') }," +
                        $"{(elements.Any(x => x.Name == "left") != false ? elements.First(x => x.Name == "left").Value : '?') }," +
                        $"{(elements.Any(x => x.Name == "width") != false ? elements.First(x => x.Name == "width").Value : '?') }," +
                        $"{(elements.Any(x => x.Name == "height") != false ? elements.First(x => x.Name == "height").Value : '?') }" +
                        $")\n");
                }
                
                Console.WriteLine(infoToPrint.ToString()); 
            }
        }
        public bool IsLoginCorrect(XElement user)
        {
            return CountUserMain(user) == 1 &&
                (CountElementsInMainWindow(user) == 4 ||
                CountElementsInMainWindow(user) == 0);
        }

        //mano users yra 2 login elementai su viskuo viduje medzio atzvilgiu, ne plokscia
        public int CountUserMain(XElement user)
        {
            return user.Elements("window").Where(window => window.Attribute("title")?.Value == "main").Count();
        }

        //cia patikrinam ar window turi 4 elementus
        public int CountElementsInMainWindow(XElement user)
        {
            //we get a number of elements in window main, if 2 main, the count will be counted accordingly
            return user.Elements("window").Where(window => window.Attribute("title")?.Value == "main").Descendants().Count();
        }
        public void Write(List<User> users)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";

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
            //XmlWriter writer = XmlWriter.Create("books.xml", settings);
            //TextWriter xmlWriter = new TextWriter(textWriter);
            //xmlWriter.Formatting = Formatting.Indented;
            //xmlWriter.Indentation = 2;
            //Serialize(xmlWriter, o, namespaces);
            //using (TextWriter stream = new StreamWriter("Config\\ggggg.xml"))
            //{
            //    stream.Formatting = Formatting.Indented;
            //    writer.Serialize(stream, users);
            //}
            //XmlSerializer writer = new XmlSerializer(typeof(List<User>));

            //using (TextWriter stream = new StreamWriter("Config\\ggggg.xml"))
            //{
            //    writer.Serialize(stream, users);
            //}


        }
        //public void Write(List<User> users)
        //{
        //    XmlSerializer writer = new XmlSerializer(typeof(List<User>));

        //    using (TextWriter stream = new StreamWriter("Config\\tryNewXML.xml"))
        //    {
        //        writer.Serialize(stream, users);
        //    }
        //}

        void CreateDirectory(string folderTitle)
        {
            if (!Directory.Exists(folderTitle))
            {
                Directory.CreateDirectory(folderTitle);
            }
        }
    }
}
