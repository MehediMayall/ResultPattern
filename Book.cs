using System.Text.Json;
using System.Linq;

namespace ResultPattern;

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
        get
        {
            if (books == null)
            {            
                using(StreamReader sr = new StreamReader("data.json"))
                {
                    string jsonString = sr.ReadToEnd();
                    this.books = JsonSerializer.Deserialize<List<Book>>(jsonString);
                }
            }
            return books;
        }
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



    public Result<List<Book>> searchBook(string bookname)
    {
        if(string.IsNullOrEmpty(bookname)) return Result<List<Book>>.Failure(BookExceptions.BookSearchTextIsEmpty());
        var foundBooks =  Books.Where(book => book.Bookname.Contains(bookname)).ToList();

        return Result<List<Book>>.Success(foundBooks);
    }

}