using System.Configuration;

namespace MonitoringApp2
{
    public class SiteSettings
    {
        public SiteSettings()
        {
        }

        public TimeSpan? CheckInterval { get; set; }
        public TimeSpan? ResponseTime { get; set; }
        public string? Site { get; set; }
        public string? Email { get; set; }
        public string? FileToWatchPath { get; set; }
    }
}
