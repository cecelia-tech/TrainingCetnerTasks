using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    // example 3x3
    internal class SquareMatrix<T>
    {
        private int _matrixSize;
        public T[] SquareMatrixElements;
        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Matrix size has to be greater than 0");
            }

            _matrixSize = size;
            SquareMatrixElements = new T [size * size];
        }

        public T this[int row, int column]
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

                return SquareMatrixElements [row * _matrixSize + column];
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

                SquareMatrixElements [row * _matrixSize + column] = value;
            }
        }
    }
}
