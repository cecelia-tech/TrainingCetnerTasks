using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._1
{
    internal static class Helper
    {
        public static Guid GenerateUniqueIdentifier(this TrainingElement trainingLesson)
        {
            return trainingLesson.UniqueIdentifier = Guid.NewGuid();
        }
    }
}
