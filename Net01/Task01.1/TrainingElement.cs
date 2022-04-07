using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._1
{
    abstract class TrainingElement
    {
        public Guid UniqueIdentifier { get; internal set; }
        private string description;

        protected TrainingElement(string description)
        {
            Description = description;
        }

        public string Description
        {
            get => description;
            set
            {
                if (value?.Length > 256)
                {
                    throw new ArgumentException("Description can't be longer than 256 characters");
                }
                description = value;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is TrainingElement material &&
                   UniqueIdentifier.Equals(material.UniqueIdentifier);
        }

        public override string ToString() => description;


    }
}
