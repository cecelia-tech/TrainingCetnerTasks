using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._1.TrainingMaterialElements
{
    internal class LinkToANetworkResource : TrainingElement
    {
        private string contentURI;
        private string linkType;

        public LinkToANetworkResource(string description) : base(description)
        {
        }

        public string ContentURI
        {
            get => contentURI;
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Content URI can't be empty");
                }
                contentURI = value;
            }
        }
        public string LinkType
        {
            get => linkType;
            set
            {
                if (value != "Unknown" || value != "Image" || value != "HTML" || value != "Audio" || value != "Video")
                {
                    throw new ArgumentException("Link type has to be either Image, HTML, Audio, Video or Unknown");
                }
                linkType = value;
            }
        }


    }
}
