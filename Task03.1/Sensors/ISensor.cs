using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    internal interface ISensor
    {
        string Title { get; set; }
        Guid UniqueIdentifier { get; set; }
        double RangeFrom { get; set; }
        double RangeTo { get; set; }
        double Value { get; set; }
        Mode SensorMode { get; set; }
        void SwitchMondes(); 
    }
}
