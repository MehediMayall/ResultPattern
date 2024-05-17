namespace BookSearch.Test;
using ResultPattern;
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
}
