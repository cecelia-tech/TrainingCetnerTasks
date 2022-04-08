﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    internal class DiagonalMatrix<T> : SquareMatrix<T>
    {
        private T[] diagonalElements;
        public DiagonalMatrix(int size) : base (size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size has to be positive and greater than zero integer");
            }

            diagonalElements = new T[size];
        }

        /// <summary>
        /// Indexer gets values of the diagonal matrix and sets it according to the restrictions. 
        /// Also rises an event in case the old value is different from the new
        /// </summary>
        /// <param name="row">Element direction in the row</param>
        /// <param name="column">Element direction in the column</param>
        /// <returns>Element of coresponding directions</returns>
        /// <exception cref="IndexOutOfRangeException">Exception is thrown when trying to access the element
        /// with negative indexers or biger than the size of the matrix
        /// </exception>
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

                return row == column ? diagonalElements[row] : default;
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
                    if (!diagonalElements[row].Equals(value))
                    {
                        T oldValue = diagonalElements[row];
                        diagonalElements[row] = value;

                        InvokeEvent(row, column, oldValue, value);
                    }
                }
            }
        }
    }
}
