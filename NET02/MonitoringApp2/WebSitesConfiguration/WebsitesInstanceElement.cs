using System.Configuration;

namespace MonitoringApp2.WebSitesConfiguration
{

    public class WebsitesInstanceElement : ConfigurationElement
    {
        [ConfigurationProperty("title", IsKey = true, IsRequired = true)]
        public string Title
        {
            get
            {
                return (string)base["title"];
            }
            set
            {
                base["title"] = value;
            }
        }

        [ConfigurationProperty("checkInterval", IsRequired = true)]
        public string CheckInterval
        {
            get
            {
                return (string)base["checkInterval"];
            }
            set
            {
                base["checkInterval"] = value;
            }
        }

        [ConfigurationProperty("responceTime", IsRequired = true)]
        public string ResponceTime
        {
            get
            {
                return (string)base["responceTime"];
            }
            set
            {
                base["responceTime"] = value;
            }
        }
        [ConfigurationProperty("site", IsRequired = true)]
        public string Site
        {
            get
            {
                return (string)base["site"];
            }
            set
            {
                base["site"] = value;
            }
        }

        [ConfigurationProperty("email", IsRequired = true)]
        public string Email
        {
            get
            {
                return (string)base["email"];
            }
            set
            {
                base["email"] = value;
            }
        }

        [ConfigurationProperty("path", IsRequired = true)]
        public string Path
        {
            get
            {
                return (string)base["path"];
            }
            set
            {
                base["path"] = value;
            }
        }
    }
}
