using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task02._1;

namespace Bandomasis
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTitleForNull()
        {
            Assert.ThrowsException<ArgumentNullException>(
                ()=> new Book("1234567890123", null, new DateTime(2022, 09, 01), new Author("John", "Stevens"), new Author("Mat", "Green"))
                );
        }

        [TestMethod]
        public void TestAddBook()
        {
            Catalog catalog = new Catalog();
            catalog.AddBook(new Book("1234567890123", "Book8", new DateTime(2022, 09, 01), new Author("John", "Stevens"), new Author("Mat", "Green")));
            foreach (var book in catalog)
            {
                Assert.IsNotNull(book);
            }
        }

        [TestMethod]
        public void TestGetBooksSortedByDate()
        {
            Catalog catalog = new Catalog();
            catalog.AddBook(new Book("1234567890123", "Book8", new DateTime(2022, 09, 01), new Author("John", "Stevens"), new Author("Mat", "Green")));
            catalog.AddBook(new Book("1234567890125", "Book2", new DateTime(2022, 04, 01), new Author("Sam", "Richers"), new Author("Mat", "Green")));
            catalog.AddBook(new Book("1234567890129", "Book3", new DateTime(2022, 12, 01), new Author("Ben", "Johnson"), new Author("Mat3", "Green3")));

            List<Book> books = new List<Book>();

            
            foreach (var book in catalog.GetBooksSortedByDate())
            {
                books.Add(book);
            }
            for (int i = 0, j = 1; j < books.Count; i++, j++)
            {
                Assert.IsTrue(books[i].PublicationDate > books[j].PublicationDate);
            }
        }

        [TestMethod]
        public void TestGetBooksByAuthor()
        {
            Catalog catalog = new Catalog();
            catalog.AddBook(new Book("1234567890123", "Book8", new DateTime(2022, 09, 01), new Author("John", "Stevens"), new Author("Mat", "Green")));
            catalog.AddBook(new Book("1234567890125", "Book2", new DateTime(2022, 04, 01), new Author("Sam", "Richers"), new Author("Mat", "Green")));
            catalog.AddBook(new Book("1234567890129", "Book3", new DateTime(2022, 12, 01), new Author("Ben", "Johnson"), new Author("Mat3", "Green3")));

            foreach (var books in catalog.GetBooksByAuthor("Mat", "Green"))
            {
                foreach (var book in books)
                {
                    Assert.IsTrue(book.Authors.Contains(new Author("Mat", "Green")));
                }
            }
        }

        [TestMethod]
        public void TestGetNumberBooksByAuthor()
        {
            Catalog catalog = new Catalog();
            catalog.AddBook(new Book("1234567890123", "Book8", new DateTime(2022, 09, 01), new Author("John", "Stevens"), new Author("Mat", "Green")));
            catalog.AddBook(new Book("1234567890125", "Book2", new DateTime(2022, 04, 01), new Author("Sam", "Richers"), new Author("Mat", "Green")));
            catalog.AddBook(new Book("1234567890129", "Book3", new DateTime(2022, 12, 01), new Author("Ben", "Johnson"), new Author("Mat3", "Green3")));

            foreach (var authorAndBooks in catalog.GetNumberOfBooksByAuthor(new Author("Mat", "Green")))
            {
                Assert.IsTrue(authorAndBooks.Item2 == 2);
            }
        }
    }
}