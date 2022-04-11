using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02._1
{
    internal class Catalog : IEnumerable<Book>
    {
        private List<Book> books = new List<Book>();

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

        public IEnumerable<IEnumerable< Book>> GetBooksByAuthor(string firstName, string lastName)
        {
            /*foreach (var book in books)
            {
                foreach (var author in book.Authors)
                {
                    if (author.FirstName == firstName && author.LastName == lastName)
                    {
                        yield return book;
                    }
                    
                }
            }*/
            yield return books.Where(book => book.Authors.Select(author => author.FirstName).ToString() == firstName && book.Authors.Select(author => author.LastName).ToString() == lastName).Select(book => book).ToList();
            //books.Where(book => book.Authors.Where(author => author.FirstName == firstName)); 
            //yield return books.Where(book => books.Where(book => book.Authors.Any(author => author.FirstName == firstName && author.LastName == lastName)));
            //books.Where(book => book.Authors.Where(author => author.FirstName == firstName && author.LastName == lastName)).Select(book => book);
            //var s = books.Where(book => books.Where(book2 => book2.Authors.Where(author => author.FirstName == author.FirstName && author.LastName == author.LastName)));
            //books.Where(book => book.Authors.
            //yield return books.Where(book => book.Authors.Where(author => author.FirstName == firstName && author.LastName == lastName)).;
            //yield return books.Where(x => (x.Authors.Where(x => x.FirstName == firstName && x.LastName == lastName))).Select(book => book);
            //books.Where(book => book.Authors.Select(x => x.FirstName == firstName && x.LastName == lastName)).Select(book => book);
            //yield return books.FindAll(x => x.Authors.Select(x => x.FirstName == firstName && x.LastName == lastName))
            //yield return s;
        }

        //veikia!!!!
        public IEnumerable<Book> GetBooksSortedByDate()
        {
            //IEnumerable<Book> orderedBooks = books.OrderByDescending(book => book.PublicationDate);

            foreach (var book in books.OrderByDescending(book => book.PublicationDate))
            {
                yield return book;
            }
        }
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
