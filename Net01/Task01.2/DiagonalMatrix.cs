using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    /// <summary>
    /// Stores diagonal matrix values and allows access to them.
    /// Rises an event if a new elements' value is different from the old one.
    /// <item>
    /// <term>_diagonalElements</term>
    /// <description>Stores matrix values which are only on the diagonal.</description>
    /// </item>
    /// </summary>
    internal class DiagonalMatrix<T> : SquareMatrix<T>
    {
        private T[] _diagonalElements;

        ///<inheritdoc/>
        public DiagonalMatrix(int size) : base (size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size has to be positive and greater than zero integer");
            }

            _diagonalElements = new T[size];
        }

        ///<inheritdoc/>
        public override T this[int row, int column]
        {
            get
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= _matrixSize ||
                    column >= _matrixSize)
                {
                    throw new IndexOutOfRangeException("Row and/or column can't be less than 0 or more or equal than the size of the array");
                }

                return row == column ? _diagonalElements[row] : default;
            }
            set
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= _matrixSize ||
                    column >= _matrixSize)
                {
                    throw new IndexOutOfRangeException("Row and/or column can't be less than 0 or more or equal than the size of the array");
                }

                if (row == column)
                {
                    if (!_diagonalElements[row].Equals(value))
                    {
                        T oldValue = _diagonalElements[row];
                        _diagonalElements[row] = value;

                        InvokeEvent(row, column, oldValue, value);
                    }
                }
            }
        }
    }
}
