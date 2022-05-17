using System.Configuration;

namespace MonitoringApp2.WebSitesConfiguration
{
    public class WebsitesConfig : ConfigurationSection
    {
        [ConfigurationProperty("webSites")]
        [ConfigurationCollection(typeof(WebSitesInstanceCollection))]
        public WebSitesInstanceCollection Websites
        {
            get
            {
                return (WebSitesInstanceCollection)this["webSites"];
            }
        }
    }
}
