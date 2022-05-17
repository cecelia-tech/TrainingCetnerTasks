using System.Configuration;

namespace MonitoringApp2.WebSitesConfiguration
{
    public class WebSitesInstanceCollection : ConfigurationElementCollection
    {
        public WebsitesInstanceElement this[int index]
        {
            get
            {
                return (WebsitesInstanceElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index); 
                }

                BaseAdd(index, value);
            }
        }

        public new WebsitesInstanceElement this[string key]
        {
            get 
            { 
                return (WebsitesInstanceElement)BaseGet(key); 
            }
            set
            {
                if (BaseGet(key) != null)
                {
                    BaseRemoveAt(BaseIndexOf(BaseGet(key)));
                }

                BaseAdd(value);
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new WebsitesInstanceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as WebsitesInstanceElement);
        }
    }
}
