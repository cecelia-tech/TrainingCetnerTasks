using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._1
{
    internal class Book
    {
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public DateTime? PublicationDate { get; private set; }
        public HashSet<Author> Authors { get; private set; } = new HashSet<Author>();

        public Book(string iSBN, string title, DateTime? publicationDate, params Author[] authors)
        {
            if (string.IsNullOrEmpty(title) || title.Length > 1000)
            {
                throw new ArgumentNullException("Title can't be empty or more than 1000 characters");
            }
            Title = title;

            ISBN = iSBN.UnifyISBN();
            
            PublicationDate = publicationDate;

            foreach (var author in authors)
            {
                Authors.Add(author);
            }

        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   ISBN == book.ISBN;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Authors);
        }
    }
}
