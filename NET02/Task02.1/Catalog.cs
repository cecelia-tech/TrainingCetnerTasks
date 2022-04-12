using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._1
{
    public class Catalog : IEnumerable<Book>
    {
        public List<Book> books = new List<Book>();

        public void AddBook (Book book)
        {
            if (book is null)
            {
                throw new NullReferenceException("The book you wish to add is null, unfortunatelly");
            }

            var bookAlradyInCatalog = books.Find(x => x.Equals(book));

            if (bookAlradyInCatalog is not null)
            {
                books[books.IndexOf(bookAlradyInCatalog)] = book;
            }
            else
            {
                books.Add(book);
            }
        }

        //panasu, kad veikia!!!!!!
        public IEnumerable<IEnumerable<Book>> GetBooksByAuthor(string firstName, string lastName)
        {
            yield return books.FindAll(book => book.Authors.Contains(new Author(firstName, lastName)));
        }

        //veikia!!!!
        public IEnumerable<Book> GetBooksSortedByDate()
        {
            foreach (var book in books.OrderByDescending(book => book.PublicationDate))
            {
                yield return book;
            }
        }
        //veikia!!!!!!
        public IEnumerable<(Author, int)> GetNumberOfBooksByAuthor(Author authorGiven)
        {
            yield return (authorGiven, books.FindAll(book => book.Authors.Contains(authorGiven)).Count());
        }

        //veikia!!!!!
        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var book in books.OrderBy(x => x.Title))
            {
                yield return book;
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
