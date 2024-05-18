namespace BookSearch;

public sealed record BookExceptions<Book> where Book : class
{
    public static Error<Book> BookSearchTextIsEmpty()=> new("Book.searchBook","Book search string is empty.");
    public static Error<Book> NoBookFound(string SearchText="")=> new("Book.searchBook",$"No book found. Search text: {SearchText}");
}