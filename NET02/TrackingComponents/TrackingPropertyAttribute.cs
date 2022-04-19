using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackingComponents
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    internal class TrackingPropertyAttribute : Attribute
    {
    }
}
