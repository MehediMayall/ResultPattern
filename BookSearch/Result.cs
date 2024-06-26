namespace BookSearch;

public sealed class Result<T> where T : class
{
    private Result(bool isSuccess, Error<T> error, T Value=null)
    {         
        IsSuccess = isSuccess;
        Error = error;
        this.Value = Value;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Error<T> Error { get; }
    public T Value { get; }

    public static Result<T> Success(T Value) => new(true, Error<T>.None, Value);
    public static Result<T> Failure(Error<T> error) => new(false, error);

}