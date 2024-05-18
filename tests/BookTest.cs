namespace BookSearch.Test;
using BookSearch;
using FluentAssertions;


public class BookTest
{


    [Theory]
    [InlineData("", false)]
    [InlineData("USA", true)]
    [InlineData("test", false)]
    [InlineData(" ", false)]
    [InlineData("0", false)]
    [InlineData(null, false)]
    public void SearchBook_ShouldReturnGivenOutput(string SearchText, bool ExpectedResult)
    {
        // Arrange
        Book book = Book.Create();

        // Act
        var result = book.searchBook(SearchText);

        // Assert
        Assert.Equal(ExpectedResult, result.IsSuccess);

        // When Success
        if (ExpectedResult)
        {
            result.Value.Should().NotBeNull();
            result.Error.Code.Should().BeNullOrEmpty();
        }
        // When Failed
        else{
            result.Error.Should().NotBeNull();
            result.Error.Description.Should().NotBeNullOrEmpty();
        }
    }

    [Fact]
    public void SearchBook_ShouldReturn_NotFoundMessage()
    {
        // Arrange
        Book book = Book.Create();

        // Act
        var result = book.searchBook("BD");

        // Assert
        result.Error.Should().NotBeNull();
        result.Error.Description.Should().Be(BookExceptions<Book>.NoBookFound().Description);
    }
    
    [Fact]
    public void SearchBook_ShouldReturn_BookSearchTextIsEmpty()
    {
        // Arrange
        Book book = Book.Create();

        // Act
        var result = book.searchBook("");

        // Assert
        result.Error.Should().NotBeNull();
        result.Error.Description.Should().Be(BookExceptions<Book>.BookSearchTextIsEmpty().Description);
    }
}
