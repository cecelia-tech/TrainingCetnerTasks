using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._1
{
    internal class Author
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public Author(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || firstName.Length > 200)
            {
                throw new ArgumentException("First name can't be empty or longer than 200 characters");
            }
            FirstName = firstName;

            if (string.IsNullOrEmpty(lastName) || lastName.Length > 200)
            {
                throw new ArgumentException("Lasnt name can't be empty or longer than 200 characters");
            }
            LastName = lastName;
        }

        public override bool Equals(object? obj)
        {
            return obj is Author author &&
                   FirstName == author.FirstName &&
                   LastName == author.LastName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName);
        }
    }
}
