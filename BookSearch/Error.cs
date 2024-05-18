namespace BookSearch;

public sealed record Error<T>(string Code, string Description) where T : class
{
    public static readonly Error<T> None = new Error<T>("","");

    public static implicit operator Result<T>(Error<T> error) 
    {
        return Result<T>.Failure(error);    
    } 
}