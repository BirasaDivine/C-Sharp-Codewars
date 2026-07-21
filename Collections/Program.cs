using System;
using System.Collections.Generic;

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public bool IsCheckedOut { get; set; }

    public override string ToString()
    {
        return $"{Title} by {Author} (ISBN: {ISBN}, Category: {Category})";
    }
}

public class LibrarySystem
{
    private LinkedList<Book> _catalog;
    private Dictionary<string, List<Book>> _booksByCategory;
    private Stack<Book> _reshelveCart;

    public LibrarySystem()
    {
        _catalog = new LinkedList<Book>();
        _booksByCategory = new Dictionary<string, List<Book>>();
        _reshelveCart = new Stack<Book>();
        Console.WriteLine("Catalog (LinkedList<Book>) initialized.");
        Console.WriteLine("BooksByCategory (Dictionary<string, List<Book>>) initialized.");
        Console.WriteLine("ReshelveCart (Stack<Book>) initialized.");
    }

    public void AddBook(Book book)
    {
        _catalog.AddLast(book);

        if (_booksByCategory.ContainsKey(book.Category))
        {
            _booksByCategory[book.Category].Add(book);
        }
        else
        {
            List<Book> newCategoryList = new List<Book>();
            newCategoryList.Add(book);
            _booksByCategory.Add(book.Category, newCategoryList);
        }

        Console.WriteLine($"Added \"{book.Title}\" to catalog under category \"{book.Category}\".");
    }

    public void DisplayCatalog()
    {
        foreach (Book book in _catalog)
        {
            Console.WriteLine($"{book.Title} by {book.Author} (ISBN: {book.ISBN}, Category: {book.Category})");
        }
        Console.WriteLine($"Total books: {_catalog.Count}");
    }

    public void DisplayBooksByCategory(string category)
    {
        if (_booksByCategory.ContainsKey(category))
        {
            Console.WriteLine($"Books in category \"{category}\":");
            foreach (Book book in _booksByCategory[category])
            {
                Console.WriteLine($"  {book.Title} by {book.Author} (ISBN: {book.ISBN})");
            }
        }
        else
        {
            Console.WriteLine($"No books found in category \"{category}\".");
        }
    }

    public bool CheckoutBook(string isbn)
    {
        foreach (Book book in _catalog)
        {
            if (book.ISBN == isbn)
            {
                if (book.IsCheckedOut)
                {
                    Console.WriteLine($"\"{book.Title}\" is already checked out.");
                    return false;
                }
                book.IsCheckedOut = true;
                Console.WriteLine($"\"{book.Title}\" checked out successfully.");
                return true;
            }
        }
        Console.WriteLine($"No book found with ISBN {isbn}.");
        return false;
    }

    public bool ReturnBook(string isbn)
    {
        foreach (Book book in _catalog)
        {
            if (book.ISBN == isbn)
            {
                book.IsCheckedOut = false;
                _reshelveCart.Push(book);
                Console.WriteLine($"\"{book.Title}\" returned and added to reshelve cart.");
                return true;
            }
        }
        Console.WriteLine($"No book found with ISBN {isbn}.");
        return false;
    }

    public void ProcessReshelveCart()
    {
        while (_reshelveCart.Count > 0)
        {
            Book book = _reshelveCart.Pop();
            Console.WriteLine($"\"{book.Title}\" has been reshelved.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Book book1 = new Book
        {
            ISBN = "123",
            Title = "Whispers of the Cosmic Winds",
            Author = "Elena Starling",
            Category = "Science Fiction"
        };

        Book book2 = new Book
        {
            ISBN = "456",
            Title = "The Last Algorithm",
            Author = "Marcus Chen",
            Category = "Technology"
        };

        LibrarySystem library = new LibrarySystem();

        Console.WriteLine("\n=== Add Books to Catalog ===");
        library.AddBook(book1);
        library.AddBook(book2);

        Console.WriteLine("\n=== Display Catalog ===");
        library.DisplayCatalog();

        Console.WriteLine("\n=== Display Books by Category ===");
        library.DisplayBooksByCategory("Science Fiction");
        library.DisplayBooksByCategory("Nonexistent Genre");

        Console.WriteLine("\n=== Test Book Circulation ===");
        library.CheckoutBook("123");   
        library.CheckoutBook("123");   
        library.CheckoutBook("999");   

        library.ReturnBook("123");
        library.ProcessReshelveCart();
    }
}