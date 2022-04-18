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
    [Serializable]
    internal class ReadsXML
    {
        public ReadsXML(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) || fileName[(fileName.Length-4)..] != ".xml")
            {
                throw new Exception("File name is incorrect");
            }
            FileName = fileName;
        }

        public ReadsXML()
        {
        }

        public string FileName { get; set; }

        private string currentDirectory = "C:\\Users\\VitaGriciute\\source\\repos\\TrainingCetnerTasks\\NET02\\Task02.2\\Config";

        public IEnumerable<XElement> GetUsers()
        {
            var purchaseOrderFilepath = Path.Combine(currentDirectory, FileName);

            XElement userInfo = XElement.Load(purchaseOrderFilepath);

            //kadangi elements, atiduoda pirmus <config> vaikus, kurie yra <login> ir todel mano users yra 2
            //pasirasom "login", nes jeigu pakliutu kitokiu negu <login>, kad visko nesugadintu

            return userInfo.Elements("login");
        }

        public bool IsLoginCorrect(XElement user)
        {
            return CountUserMain(user) != 1 ||
                CountElementsInMainWindow(user) != 4 ||
                CountElementsInMainWindow(user) != 0;
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
        
        public string GetUsersInfoToPrint (XElement user)
        {
            StringBuilder infoToPrint = new StringBuilder();

            infoToPrint.Append($"Login: {user.Attribute("name")?.Value} \n");

            if (CountUserMain(user) == 1)
            {
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
            }
            return infoToPrint.ToString();
        }
    }
}
