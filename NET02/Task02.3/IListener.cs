using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._3
{
    public interface IListener 
    {
        public Config settings { get; set; }
        void Log (string message);
    }
}
