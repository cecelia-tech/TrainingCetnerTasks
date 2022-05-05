using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MonitoringApp2
{
    internal class SiteSettingsLoader
    {
        public SiteSettingsLoader()
        {
        }
        public SiteSettingsLoader(List<SiteSettings> settings)
        {
            Settings = settings ?? throw new ArgumentNullException("No settings provided");
            SaveToXML();
        }

        private List<SiteSettings> Settings = new List<SiteSettings>();

        public void AddSetting (SiteSettings webSettings)
        {
            Settings.Add(webSettings ?? throw new ArgumentNullException("No settings provided"));
            SaveToXML();
        }

        private void SaveToXML()
        {
            if (Settings.Count() != 0)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<SiteSettings>));

                using (FileStream stream = new FileStream("SiteSettings.xml", FileMode.OpenOrCreate))
                {
                    serializer.Serialize(stream, Settings);
                }
            }
        }

        public List<SiteSettings> GetSettings()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<SiteSettings>));

            List<SiteSettings> settings;

            using (Stream reader = new FileStream("SiteSettings.xml", FileMode.Open))
            {
                settings = (List<SiteSettings>)serializer.Deserialize(reader);
            }
            return settings;
        }
    }
}
