using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._1.TrainingMaterialElements
{
    internal class TextMaterial : TrainingElement
    {
        private string text;

        public TextMaterial(string description) : base(description)
        {
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                if (value.Length > 10000 || value.Length == 0)
                {
                    throw new ArgumentException("Text length can't be more than 10000 character or be empty");
                }
                else
                {
                    text = value;
                }
            }
        }

    }
}
