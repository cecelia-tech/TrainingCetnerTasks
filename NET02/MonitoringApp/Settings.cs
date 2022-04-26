using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringApp
{
    public class Settings
    {
        public TimeSpan CheckInterval { get; set; }
        public TimeSpan ResponceTime { get; set; }
        public List<string> Sites { get; set; } = new List<string>();
        public string? Email { get; set; }
        public string Path { get; set; }
    }
}
