using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01._1.TrainingMaterialElements;

namespace Task01._1
{
    internal class TrainingLesson : TrainingElement, IVersionable, ICloneable
    {
        const int TRAINING_MATERIAL_ARRAY_SIZE = 10;
        private TrainingElement[] trainningMaterials;
        private int trainingMaterialsIndex = 0;
        private uint[] version = new uint[2];
        public TrainingLesson(string description) : base(description)
        {
            trainningMaterials = new TrainingElement[TRAINING_MATERIAL_ARRAY_SIZE];
        }

        public void AddLessonMaterial(TrainingElement newMaterial)
        {
            if (trainingMaterialsIndex == TRAINING_MATERIAL_ARRAY_SIZE)
            {
                throw new ArgumentException("Training materials are full");
            }

            trainningMaterials[trainingMaterialsIndex] = newMaterial;
            trainingMaterialsIndex++;
        }

        public object Clone()
        {
            TrainingLesson clonedLesson = (TrainingLesson)this.MemberwiseClone();
            clonedLesson.trainningMaterials = new TrainingElement[TRAINING_MATERIAL_ARRAY_SIZE];
            Array.Copy(this.trainningMaterials, clonedLesson.trainningMaterials, trainingMaterialsIndex);

            return clonedLesson;
        }

        public string TrainingType()
        {
            if (trainingMaterialsIndex == 0)
            {
                return "This lesson doesn't have any material yet.";
            }

            for (int i = 0; i < trainningMaterials.Length; i++)
            {
                if (trainningMaterials[i] is VideoMaterial)
                {
                    return "This lesson is VideoLesson";
                }
            }
            return "This lesson is TextLesson";
        }
        public string Version
        {
            get
            {
                if (version[0] == default && version[1] == default)
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
                for (int i = 0; i < versionNumbers.Length; i++)
                {
                    version[i] = uint.Parse(versionNumbers[i]);
                }
            }
        }

    }
}
