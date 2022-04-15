using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Task02._2
{
    internal class XMLtoJSON
    {
        public XMLtoJSON(string user)
        {
            User = user;
        }

        private string User;

        //XmlSerializer serializer = new XmlSerializer(typeof(List<string>));

        public void ConvertXMLtoJSON()
        {
            //var json = JsonConvert.SerializeXmlNode(doc, Formatting.None, true);

            using (var fs = File.Create("sample.json"))
            {
                JsonSerializer.SerializeAsync(fs, User);
                //JsonSerializer.
            }
        }
        
    }
}
