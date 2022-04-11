using Task02._1;

Catalog catalog = new Catalog();

Book book1 = new Book("1234567890123", "Book7", new DateTime(2022, 09, 01), new Author("John", "Stevens"), new Author("Mat", "Green"));
Book book2 = new Book("1234567890125", "Book2", new DateTime(2022, 04, 01), new Author("Sam", "Richers"), new Author("Mat", "Green"));
Book book3 = new Book("1234567890129", "Book3", new DateTime(2022, 12, 01), new Author("Ben", "Johnson"), new Author("Mat3", "Green3"));

catalog.AddBook(book1);
catalog.AddBook(book2);
catalog.AddBook(book3);

//Console.WriteLine(catalog.GetBooksByAuthor("John", "Stevens"));
foreach (var item in catalog.GetBooksSortedByDate())
{
    Console.WriteLine(item.PublicationDate);
}

foreach (var item in catalog.GetBooksByAuthor("John", "Stevens"))
{
    Console.WriteLine(item.Title);
}

/*foreach (var item in catalog)
{
    Console.WriteLine(item.Title);
}*/
