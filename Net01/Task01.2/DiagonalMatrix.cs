using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    /// <summary>
    /// Stores numeric diagonal matrix values and allows access to them.
    /// Rises an event if a new elements' value is different from the old one.
    /// <item>
    /// <term>_diagonalElements</term>
    /// <description>Stores matrix values which are only on the diagonal.</description>
    /// </item>
    /// </summary>
    internal class DiagonalMatrix<T> : SquareMatrix<T>
    {
        

        ///<inheritdoc/>
        public DiagonalMatrix(int size) : base ()
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size has to be positive and greater than zero integer");
            }
            _size = size;
            _elements = new T[size];
            //InstattiateArray(size);
        }

        /*protected override void InstattiateArray(int size)
        {
            _diagonalElements = new T[size * size];
        }*/
        ///<inheritdoc/>
        public override T this[int row, int column]
        {
            get
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= _size ||
                    column >= _size)
                {
                    throw new IndexOutOfRangeException("Row and/or column can't be less than 0 or more or equal than the size of the array");
                }

                return row == column ? (_elements[row])! : (default)!;
            }
            set
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= _size ||
                    column >= _size)
                {
                    throw new IndexOutOfRangeException("Row and/or column can't be less than 0 or more or equal than the size of the array");
                }

                if (row == column)
                {
                    if (!(_elements[row])!.Equals(value))
                    {
                        T oldValue = _elements[row];
                        _elements[row] = value;

                        InvokeEvent(row, column, oldValue, value);
                    }
                }
            }
        }
    }
}
