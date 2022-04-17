using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task02._2
{
    [Serializable]
    //[XmlRoot(ElementName = "window")]
    public class WindowSettings
    {
        public WindowSettings()
        {
        }

        public WindowSettings(string name, int? top, int? left, int? width, int? height)
        {
            Title = name ?? throw new ArgumentNullException(nameof(name));

            if (top < 0 || left < 0 || width < 0 || height < 0)
            {
                throw new ArgumentException("Window settings can't be negative");
            }

            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        //[XmlAttribute("title")]
        public string Title { get; set; }
        //[XmlElement(ElementName = "top")]
        public int? Top { get; set; }
        //[XmlElement(ElementName = "left")]
        public int? Left { get; set; }
        //[XmlElement(ElementName = "width")]
        public int? Width { get; set; }
        //[XmlElement(ElementName = "height")]
        public int? Height { get; set; }

        //pasidarom nauja metoda, kuris atiduos nauja object su naujom reiksmem saugojimui
        //cia tikriausiai kai patikrinsim ar yra visos dalys reikiamos
        public WindowSettings GetCorrectedWindowSettings()
        {
            return new WindowSettings(Title, Top ?? 0, Left ?? 0, Width ?? 400, Height ?? 150);
        }

    }
}
