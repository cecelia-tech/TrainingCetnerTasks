using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task02._2
{
    internal class NewDirectory
    {

        string folderTitle;

        public NewDirectory(string folderTitle)
        {
            this.folderTitle = folderTitle ?? throw new ArgumentNullException(nameof(folderTitle));
            CreateDirectory();
        }

        //static string path = Directory.GetCurrentDirectory();

        //string filePath = Path.Combine(path, folderTitle);

        internal void CreateDirectory()
        {
            if (!Directory.Exists(folderTitle))
            {
                Directory.CreateDirectory(folderTitle);
            }
        }
         
}
}
