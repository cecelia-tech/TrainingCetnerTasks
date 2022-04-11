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
            //return books.Where(book => book.Authors.Contains(authorGiven)).GroupBy(book => book.Title).Select(book => (authorGiven, book.Count()));
            yield return (authorGiven, books.FindAll(book => book.Authors.Contains(authorGiven)).Count());
            //books.Contains(authorGiven)
            //books.Where(book => book.Authors.Where(author => author.Equals(authorGiven))
            //IEnumerable< (Author, int) > s = 
            //yield return books.GroupBy(book => book.Authors).Where(book => book.Key.Contains(authorGiven)).Select(book => (authorGiven, book.Count()));
            //return s;
            // yield return books.Select(book => (authorGiven, book.Authors.Where(author => authorGiven.Equals(author)).Count())).ToList();
            //return books.Select(book => (authorGiven, books.Select(book => book.Authors.Where(author => author.Equals(authorGiven))).Count())).ToList();
            //return books.GroupBy(book => book.Authors.Equals(author)).Select(book => (book.Key, book.Count()));
            //return books.SelectMany(book => (book.Authors.Equals(author), books.FindAll(book => book.Authors.Equals(author)).Count()));
            //return books.Select(book => (books.FindAll(book => book.Authors.Equals(author)), books.FindAll(book => book.Authors.Equals(author)).Count()));
            //books.FindAll(book => book.Authors.Equals(author));
            //return books.GroupBy(book => author).Select(book => (book.Key.FirstName, book.Count)).ToList();
        }
        /*public IEnumerable< Book> ArTuri(Author a)
        {
            books.GroupBy(book => )
            foreach (var item in books.Where(book => book.Authors.Find(a)))
            {
                yield return item;
            }
            //yield return books.Where(book => book.Authors.Contains(a)); 
        }*/
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
