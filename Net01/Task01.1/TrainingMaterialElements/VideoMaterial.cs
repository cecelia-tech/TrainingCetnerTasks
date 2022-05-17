using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._1.TrainingMaterialElements
{
    internal class VideoMaterial : TrainingElement, IVersionable
    {
        private string videoContent;
        private string splashScreen;
        private string videoFormat;
        private uint[] version = new uint[2];
        public VideoMaterial(string description) : base(description)
        {
        }

        public string VideoContent
        {
            get => videoContent;
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("URI of video content can't be empty");
                }
                videoContent = value;
            }
        }

        public string SplashScrean
        {
            get => splashScreen;
            set
            {
                if (value is null || value.Equals(string.Empty))
                {
                    throw new ArgumentException("Splash screen can't be empty or null");
                }
                splashScreen = value;
            }
        }
        public string VideoFormat
        {
            get => videoFormat;
            set
            {
                if (value != "Unknown" || value != "Avi" || value != "Mp4" || value != "Flv")
                {
                    throw new ArgumentException("Video format has to be either Unknown, Avi, Mp4 or Flv");
                }
                videoFormat = value;
            }
        }

        public string Version
        {
            get
            {
                if (version[0] == default & version[1] == default)
                {
                    return "Version is not set";
                }

                StringBuilder videoMaterialVersion = new StringBuilder();

                videoMaterialVersion.Append(version[0]).Append(".").Append(version[1]);

                return videoMaterialVersion.ToString();
            }
            set
            {
                string[] versionNumbers = value.Split('.');
                if (versionNumbers.Length > 2)
                {
                    throw new ArgumentException("Version can consist of two positive integers separated by '.'");
                }
                for (int i = 0; i < version.Length; i++)
                {
                    version[i] = uint.Parse(versionNumbers[i]);
                }
            }
        }
    }
}
