using System;
using System.Collections;
using System.Text;

namespace Task01._2
{
    /// <summary>
    /// Stores and asigns numeric matrix values, 
    /// rises events when the new element is not the same as the previous.
    /// <item>
    /// <term>_matrixSize</term>
    /// <description>Size of the matrix</description>
    /// </item>
    /// <item>
    /// <term>_squareMatrixElements</term>
    /// <description>Stores values of a matrix</description>
    /// </item>
    /// <item>
    /// <term>InvokeEvent</term>
    /// <description>Invokes the event</description>
    /// </item>
    /// <item>
    /// <term>Anouncement</term>
    /// <description>Displys the information passes from the event</description>
    /// </item>
    /// </summary>
    internal class SquareMatrix<T> : IEnumerable<T>
    {
        protected int _size;
        protected T[] _elements;
        public event EventHandler<StoredValues<T>> ChangedElements;

        /// <summary>
        /// Initiates the array to store martix values,
        /// subscribes to the events.
        /// </summary>
        /// <param name="size">The size of the matrix</param>
        /// <exception cref="ArgumentException">If size value passed is negative or equal to zero</exception>
        public SquareMatrix(int size) : this ()
        {
            if (size <= 0)
            {
                throw new ArgumentException("Matrix size has to be greater than 0");
            }

            _size = size;
            _elements = new T[size * size];
        }

        protected SquareMatrix()
        {
            ChangedElements += Anouncement;
            ChangedElements += delegate (object? obj, StoredValues<T> values)
            {
                Console.WriteLine($"2 Element at [{values.Row}, {values.Column}] has been changed from {values.OldValue} to {values.NewValue}");
            };
            ChangedElements += (object? obj, StoredValues<T> values) => { Console.WriteLine($"3 Element at [{values.Row}, {values.Column}] has been changed from {values.OldValue} to {values.NewValue}"); };
        }

        /// <summary>
        /// Provides access and to modify the values of a matrix
        /// </summary>
        /// <returns>Element of a matrix at specified location</returns>
        /// <exception cref="IndexOutOfRangeException">If indices are incorrect</exception>
        public virtual T this[int row, int column]
        {
            get
            {
                CheckValues(row, column);

                return _elements[row * _size + column];
            }
            set
            {
                CheckValues(row, column);

                if (!(_elements[row * _size + column])!.Equals(value))
                {
                    T oldValue = _elements[row * _size + column];
                    _elements[row * _size + column] = value;

                    InvokeEvent(row, column, oldValue, value);
                }
            }
        }

        /// <summary>
        /// Checks if values are in rande required
        /// </summary>
        /// <param name="row">On which row the element is</param>
        /// <param name="column">On which column the element is</param>
        /// <exception cref="IndexOutOfRangeException">If indices are incorrect</exception>
        protected void CheckValues(int row, int column)
        {
            if (row < 0 ||
                    column < 0 ||
                    row >= _size ||
                    column >= _size)
            {
                throw new IndexOutOfRangeException("Row and/or column can't be less than 0 or more or equal than the size of the array");
            }
        }

        /// <summary>
        /// Invokes the event
        /// </summary>
        /// <param name="row">On which row the element is</param>
        /// <param name="column">On which column the element is</param>
        /// <param name="oldvalue">Old elements' value before asigning a new one</param>
        /// <param name="value">New value of the element</param>
        protected void InvokeEvent(int row, int column, T oldvalue, T value)
        {
            ChangedElements?.Invoke(this, new StoredValues<T>(row, column, oldvalue, value));
        }
        
        /// <summary>
        /// Displays the information invoked with the event
        /// </summary>
        /// <param name="sender">Which object is sending the information</param>
        /// <param name="values">Information provided by the sender</param>
        public void Anouncement(object? sender, StoredValues<T> values)
        {
            Console.WriteLine($"1 Element at [{values.Row}, {values.Column}] has been changed from {values.OldValue} to {values.NewValue}");
        }

        /// <summary>
        /// Allows the instance of the class to be enumerated as a collection
        /// </summary>
        /// <returns>Elements of a square matrix</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    yield return this[j, i];
                }
            }
        }

        //kad duotu array
        public IEnumerable<IEnumerable<T>> GetArrayOfElements()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return GetRowElements(i);
            }
        }

        public IEnumerable<T> GetRowElements(int row)
        {
            for (int j = 0; j < _size; j++)
            {
                yield return this[row, j];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Custom implementation of ToString()
        /// <item>
        /// <term>sparseMatrix</term>
        /// <description>Stores matrix elements in a string</description>
        /// </item>
        /// <item>
        /// <term>newLineCount</term>
        /// <description>Stores value after which a new line '\n' has to be inserted</description>
        /// </item>
        /// </summary>
        /// <returns>Matrix represented as a string</returns>
        public override string ToString()
        {
            StringBuilder matrix = new StringBuilder();
           
            foreach (var row in GetArrayOfElements())
            {
                string rowOfElements = string.Join('\t', row);
                matrix.Append(rowOfElements).Append('\n');
            }

            return matrix.ToString();
        }
    }
}
