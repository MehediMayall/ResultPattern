
using ResultPattern;

var book = Book.Create();

var result = book.searchBook("Foundation");
if (result.IsFailure) System.Console.WriteLine(result.Error.Description);
else
{
    foreach(Book item in result.Value)
    {
        // System.Console.WriteLine($"Book Name: {item.Bookname}, Author: {item.Bookname}");
    }
}

