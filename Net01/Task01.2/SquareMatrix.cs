using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    internal class SquareMatrix<T> : IEnumerable<T>
    {
        protected int _matrixSize;
        private T[] _squareMatrixElements;

        public event EventHandler<StoredValues<T>> ChangedElements;
        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Matrix size has to be greater than 0");
            }

            _matrixSize = size;
            _squareMatrixElements = new T [size * size];

            ChangedElements += Anouncement;
            ChangedElements += delegate (object? obj, StoredValues<T> values)
            {
                Console.WriteLine($"2 Element at [{values.Row}, {values.Column}] has been changed from {values.OldValue} to {values.NewValue}");
            };
            ChangedElements += (object? obj, StoredValues<T> values) => { Console.WriteLine($"3 Element at [{values.Row}, {values.Column}] has been changed from {values.OldValue} to {values.NewValue}"); };
        }

        public virtual T this[int row, int column]
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

                return _squareMatrixElements [row * _matrixSize + column];
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

                if (!_squareMatrixElements[row * _matrixSize + column].Equals(value))
                {
                    T oldValue = _squareMatrixElements[row * _matrixSize + column];
                    _squareMatrixElements[row * _matrixSize + column] = value;

                    InvokeEvent(row, column, oldValue, value);
                }
            }
        }

        protected void InvokeEvent(int row, int column, T oldvalue, T value)
        {
            ChangedElements?.Invoke(this, new StoredValues<T>(row, column, oldvalue, value));
        }
        
        public void Anouncement(object? sender, StoredValues<T> values)
        {
            Console.WriteLine($"1 Element at [{values.Row}, {values.Column}] has been changed from {values.OldValue} to {values.NewValue}");
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _matrixSize; i++)
            {
                for (int j = 0; j < _matrixSize; j++)
                {
                    yield return this[j, i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sparseMatrix = new StringBuilder();

            int newLineCount = 0;

            foreach (var item in this)
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
    }
}
