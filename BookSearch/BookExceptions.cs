namespace ResultPattern;

public sealed record BookExceptions
{
    public static Error BookSearchTextIsEmpty()=> new Error("Book","Book search string is empty.");
    public static Error NoBookFound()=> new Error("Book","No book found.");
}