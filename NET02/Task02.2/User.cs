using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task02._2
{
    //[XmlInclude(typeof(WindowSettings))]
    [Serializable]
    //[XmlRoot(ElementName = "window")]
    //[XmlRoot("login")]
    public class User
    {
        //our user can have multiple window settings
        //[XmlArray("windows")]
        //[XmlArrayItem("window")]
        //[XmlArrayItem(Attribute = "g")]
        //[XmlElement("window")]
        public List<WindowSettings> windowSettings = new List<WindowSettings>();

        public User()
        {
        }

        public User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        //[XmlAttribute("name")]
        public string Name { get; set; }

        internal void AddWindowSettings(WindowSettings windowSetting)
        {
            windowSettings.Add(windowSetting ?? throw new ArgumentNullException(nameof(windowSetting)));
        }
    }
}
