
using BookSearch;

var book = Book.Create();

// var result = book.searchBook("Foundation");
var result = book.searchBook("UA");
if (result.IsFailure) System.Console.WriteLine(result.Error.Description);
else
{
    foreach(Book item in result.Value)
    {
        System.Console.WriteLine($"\tBook Name: {item.Bookname}, Author: {item.Bookname}, Country: {item.Country}");
    }
}


