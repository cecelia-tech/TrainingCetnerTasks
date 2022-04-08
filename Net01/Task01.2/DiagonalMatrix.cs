using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    internal class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public int Size { get; private set; }
        private T[] diagonalElements;
        public DiagonalMatrix(int size) : base (size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size has to be positive and greater than zero integer");
            }
            this.Size = size;
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
                    row >= Size ||
                    column >= Size)
                {
                    throw new IndexOutOfRangeException("Row and/or column can't be less than 0 or more or equal than the size of the array");
                }

                return row == column ? diagonalElements[row] : default;
            }
            set
            {
                if (row < 0 ||
                    column < 0 ||
                    row >= Size ||
                    column >= Size)
                {
                    throw new IndexOutOfRangeException("Row and/or column can't be less than 0 or more or equal than the size of the array");
                }

                if (row == column)
                {
                    T oldValue = diagonalElements[row];
                    diagonalElements[row] = value;
                    InvokeEvent(row, column, oldValue, value);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sparseMatrix = new StringBuilder();

            int newLineCount = 0;

            foreach (var item in this)
            {
                if (newLineCount < Size)
                {
                    sparseMatrix.Append(item).Append('\t');
                    newLineCount++;

                    if (newLineCount == Size)
                    {
                        newLineCount = 0;
                        sparseMatrix.Append('\n');
                    }
                }
            }
            return sparseMatrix.ToString();
        }
        /// <summary>
        /// Method is used when invoking the event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="values">Values consists of indexes(Index) of an element in the diagonal matrix, 
        /// an old value (OldValue) and a new value (NewValue). 
        ///</param>
        /*public void Anouncement(object sender, StoredValues<T> values)
        {
            Console.WriteLine($"Element at [{values.Row}, {values.Row}] has been changed from {values.OldValue} to {values.NewValue}");
        }*/
    }
}
