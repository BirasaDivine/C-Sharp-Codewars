using System;
using System.Collections.Generic;

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public List<Book> SearchBooksByTitle(string title)
    {
        List<Book> results = new List<Book>();
        foreach (Book book in books)
        {
            if (book.Title == title)
            {
                results.Add(book);
            }
        }
        return results;
    }

    public void DisplayAllBooks()
    {
        foreach (Book book in books)
        {
            Console.WriteLine($"{book.Title} by {book.Author}");
        }
    }
}