using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    internal class StoredValues<T> : EventArgs
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public T OldValue { get; private set; }
        public T NewValue { get; private set; }

        public StoredValues(int row, int column, T oldValue, T newValue)
        {
            Row = row;
            Column = column;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
