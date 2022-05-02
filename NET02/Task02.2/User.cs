using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task02._2
{
    [Serializable]
    public class User
    {
        public User()
        {
        }

        public User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public string Name { get; set; }
        public List<WindowSettings> WindowSettings { get; set; } = new List<WindowSettings>();

        public void AddWindowSettings(WindowSettings windowSetting)
        {
            WindowSettings.Add(windowSetting ?? throw new ArgumentNullException(nameof(windowSetting)));
        }
    }
}
