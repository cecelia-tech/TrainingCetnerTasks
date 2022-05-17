using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors
{
    internal class Sensor : ISensor
    {
        public string Title { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Guid UniqueIdentifier { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double RangeFrom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double RangeTo { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Mode SensorMode { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void SwitchMondes()
        {
            throw new NotImplementedException();
        }
    }
}
