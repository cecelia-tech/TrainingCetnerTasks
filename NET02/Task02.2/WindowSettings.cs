﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._2
{
    internal class WindowSettings
    {
        public WindowSettings(string name, int top, int left, int width, int height)
        {
            Name = name;
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }

        public string Name { get; set; }
        public int? Top { get; set; }
        public int? Left { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        //pasidarom nauja metoda, kuris atiduos nauja object su naujom reiksmem saugojimui
        public WindowSettings GetCorrectedWindowSettings()
        {
            return new WindowSettings(Name, Top ?? 0, Left ?? 0, Width ?? 400, Height ?? 150);
        }

    }
}
