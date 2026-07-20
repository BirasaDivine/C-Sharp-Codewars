using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
  class Program
  {
    static void Main()
    {
      
      Library library = new Library();

      // Task 7: Add some sample books
      Book book1 = new Book { Title = "1984", Author = "George Orwell" };
      Book book2 = new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee" };
      library.AddBook(book1);
      library.AddBook(book2);

      
      List<Book> results = library.SearchBooksByTitle("1984");
      foreach (Book book in results)
      {
        Console.WriteLine($"{book.Title} by {book.Author}");
      }

      
      library.DisplayAllBooks();
    }
  }
}