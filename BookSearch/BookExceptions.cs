namespace BookSearch;

public sealed record BookExceptions<Book> where Book : class
{
    public static Error<Book> BookSearchTextIsEmpty()=> new Error<Book>("Book","Book search string is empty.");
    public static Error<Book> NoBookFound()=> new Error<Book>("Book","No book found.");
}