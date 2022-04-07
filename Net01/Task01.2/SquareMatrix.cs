using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
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

        public override string ToString()
        {
            StringBuilder sparseMatrix = new StringBuilder();

            int newLineCount = 0;

            foreach (var item in SquareMatrixElements)
            {
                if (newLineCount < _matrixSize)
                {
                    sparseMatrix.Append(item).Append('\t');
                    newLineCount++;

                    if (newLineCount == _matrixSize)
                    {
                        newLineCount = 0;
                        sparseMatrix.Append('\n');
                    }
                }
            }
            return sparseMatrix.ToString();
        }
        /*
        public override string? ToString()
        {
            StringBuilder squareMatrixString = new StringBuilder();
            foreach (var item in SquareMatrixElements)
            {
                squareMatrixString.Append(item).Append('\t');
            }
            return ;
        }*/
    }
}
