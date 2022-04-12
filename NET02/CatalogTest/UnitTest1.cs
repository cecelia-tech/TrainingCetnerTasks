using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task02._1;

namespace CatalogTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var catalog = new Catalog();
            Book book1 = new Book("1234567890123", "Book7", new DateTime(2022, 09, 01), new Author("John", "Stevens"), new Author("Mat", "Green"));
            catalog.AddBook(book1);
        }
    }
}