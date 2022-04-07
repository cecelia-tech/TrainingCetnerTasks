using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    internal class StoredValues<T> : EventArgs
    {
        public int Index { get; private set; }
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }

        public StoredValues(int index, T oldValue, T newValue)
        {
            Index = index;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
