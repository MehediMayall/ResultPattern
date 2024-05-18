using System.Text.Json;
using System.Linq;

namespace BookSearch;

public sealed class Book
{
    
    private Book()
    {
        
    }
    private Book(string name, string author, int year, string bookname, string country, string isbn)
    {
        Name = name;
        Author = author;
        Year = year;
        Bookname = bookname;
        Country = country;
        Isbn = isbn;
    }

    public string Name { get; } = string.Empty;
    public string Author { get; } = string.Empty;
    public int Year { get; } = 0;
    public string Bookname { get; } = string.Empty;
    public string Country { get; } = string.Empty;
    public string Isbn { get; } = string.Empty;

    private  List<Book> books {get; set;}

    public List<Book> Books
    {
        get{return books ?? loadBook();}
    }

    private List<Book> loadBook()
    {
        Book book1 = new("Dune","Frank Herbert",1965,"Dune","USA","9780441013593");
        Book book2 = new("The War of the Worlds","H.G. Wells",1898,"The War of the Worlds","United Kindom","9781853260230");
        Book book3 = new("Foundation","Isaac Asimov",1961,"Foundation","USA","9780553293357");
        Book book4 = new("Neuromancer","William Gibson",1984,"Sprawl Trilogy","Canada","9780441569595");
        books = new List<Book>([book1,book2, book3, book4]);
        return books;
    }


    public static Book Create()
    {
        return new Book();
    }

    public static Book Create(string name, string author, int year, string bookname, string country, string isbn)
    {
        var book = new Book(
            name,
            author,
            year,
            bookname,
            country,
            isbn
        );

        return book;
    }



    public Result<List<Book>> searchBook(string searchText)
    {
        if(string.IsNullOrEmpty(searchText)) return BookExceptions<List<Book>>.BookSearchTextIsEmpty();
        var foundBooks =  Books.Where(book => book.Bookname.Contains(searchText) || 
            book.Country.Contains(searchText)
        ).ToList();

        if (foundBooks.Count == 0) return BookExceptions<List<Book>>.NoBookFound(searchText);

        return Result<List<Book>>.Success(foundBooks);
    }

}