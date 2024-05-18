
using BookSearch;

var book = Book.Create();

// var result = book.searchBook("Foundation");
var searchResult1 = book.searchBook("UA");
if (searchResult1.IsFailure) System.Console.WriteLine(searchResult1.Error.Description);

var searchResult2 = book.searchBook("USA");
if (searchResult2.IsSuccess)
{
    foreach(Book item in searchResult2.Value)
    {
        System.Console.WriteLine($"\tBook Name: {item.Bookname}, Author: {item.Bookname}, Country: {item.Country}");
    }
}


