using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._2
{
    internal class User
    {
        //our user can have multiple window settings
        List<WindowSettings> windowSettings = new List<WindowSettings>();

        public User(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        public string Name { get; private set; }

        internal void AddWindowSettings(WindowSettings windowSetting)
        {
            windowSettings.Add(windowSetting ?? throw new ArgumentNullException(nameof(windowSetting)));
        }
    }
}
