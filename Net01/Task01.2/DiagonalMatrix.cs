using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01._2
{
    //diagonal matrix is a square matrix in which the elements outside the main
    //diagonal have default values of the element type
    internal class DiagonalMatrix<T>
    {
        //this is a delegate, which defines that the method is void and takes object and StoredValues as argument
        //we have object here because the EventHandler requires it, so we don't need to change it
        public delegate void DelegateForEvent(object obj, StoredValues<T> val);
        //this event will subscribe to the methods
        public event DelegateForEvent EventWithDelegate;


        //simple eventHandler
        public event EventHandler<StoredValues<T>> ChangedElements;

        public int Size { get; private set; }
        private T[] diagonalElements;
        public DiagonalMatrix(int size)
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
        public T this[int row, int column]
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
                    if (!diagonalElements[row].Equals(value))
                    {
                        T oldValue = diagonalElements[row];
                        diagonalElements[row] = value;
                        //subscribes to the event with defined delegate
                        EventWithDelegate += Anouncement;
                        //subscribing to the event with the anonimous method
                        EventWithDelegate += delegate (object obj, StoredValues<T> values)
                        {
                            Console.WriteLine("Subscribing to the anonimous");
                        };
                        EventWithDelegate += (object obj, StoredValues<T> val) => { Console.WriteLine("Subscribing to the lambda"); };
                        //subscribes to the event described with event handler
                        ChangedElements += Anouncement;
                        //invokes delegate described event
                        EventWithDelegate?.Invoke(this, new StoredValues<T>(row, oldValue, value));
                        //invokes eventArgs described delegate
                        ChangedElements?.Invoke(this, new StoredValues<T>(row, oldValue, value));
                    }
                }
            }
        }
        /// <summary>
        /// Method is used when invoking the event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="values">Values consists of indexes(Index) of an element in the diagonal matrix, 
        /// an old value (OldValue) and a new value (NewValue). 
        ///</param>
        public void Anouncement(object sender, StoredValues<T> values)
        {
            Console.WriteLine($"Element at [{values.Index}, {values.Index}] has been changed from {values.OldValue} to {values.NewValue}");
        }
    }
}
