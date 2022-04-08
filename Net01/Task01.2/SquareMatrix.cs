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

        /// <summary>
        /// Delegate for the event
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="values"></param>
        /*public delegate void DelegateForEvent(object obj, StoredValues<T> values);

        public event DelegateForEvent EventWithDelegate;
        */

        //simple eventHandler
        public event EventHandler<StoredValues<T>> ChangedElements;
        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Matrix size has to be greater than 0");
            }

            _matrixSize = size;
            SquareMatrixElements = new T [size * size];

            ChangedElements += Anouncement;
            ChangedElements += delegate (object obj, StoredValues<T> values)
            {
                Console.WriteLine("Subscribing to the anonimous");
            };
            ChangedElements += (object obj, StoredValues<T> val) => { Console.WriteLine("Subscribing to the lambda"); };

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

                if (!SquareMatrixElements[row * _matrixSize + column].Equals(value))
                {
                    T oldValue = SquareMatrixElements[row * _matrixSize + column];
                    SquareMatrixElements[row * _matrixSize + column] = value;
                    //subscribes to the event with defined delegate
                    //EventWithDelegate += Anouncement;
                    //subscribing to the event with the anonimous method
                    //EventWithDelegate += delegate (object obj, StoredValues<T> values)
                    //{
                    //    Console.WriteLine("Subscribing to the anonimous");
                    //};
                    //EventWithDelegate += (object obj, StoredValues<T> val) => { Console.WriteLine("Subscribing to the lambda"); };
                    //subscribes to the event described with event handler
                    
                    //invokes delegate described event
                    //EventWithDelegate?.Invoke(this, new StoredValues<T>(row, oldValue, value));
                    //invokes eventArgs described delegate
                    ChangedElements?.Invoke(this, new StoredValues<T>(row, oldValue, value));
                    
                }
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
        public void Anouncement(object sender, StoredValues<T> values)
        {
            Console.WriteLine($"Element at [{values.Index}, {values.Index}] has been changed from {values.OldValue} to {values.NewValue}");
        }
    }
}
