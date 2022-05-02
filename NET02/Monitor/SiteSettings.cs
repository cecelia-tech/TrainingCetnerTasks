using System.Configuration;

namespace Monitor
{
    public class SiteSettings
    {
        public SiteSettings()
        {
            CheckInterval = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("CheckInterval"));
            ResponseTime = TimeSpan.Parse(ConfigurationManager.AppSettings.Get("ResponceTime"));
            Site = ConfigurationManager.AppSettings.Get("Site");
            Email = ConfigurationManager.AppSettings.Get("Email");
            FileToWatchPath = ConfigurationManager.AppSettings.Get("Path");
        }

        public TimeSpan? CheckInterval { get; set; }
        public TimeSpan? ResponseTime { get; set; }
        public string? Site { get; set; }
        public string? Email { get; set; }
        public string? FileToWatchPath { get; set; }
    }
}
