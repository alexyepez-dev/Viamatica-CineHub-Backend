using VMT.CineHub.Domain.Enums;

namespace VMT.CineHub.Domain.Shared;
public sealed class Result<T>
{
    public bool IsSuccess { get; }
    public T Value { get; }
    public string Error { get; }
    public ErrorType ErrorType { get; }

    private Result
    (
        bool isSuccess,
        T value,
        string error,
        ErrorType errorType
    )
    {
        IsSuccess = isSuccess;
        Value = value;
        Error = error;
        ErrorType = errorType;
    }

    public static Result<T> Ok(T value) => new
    (
        true,
        value,
        null!,
        ErrorType.None
    );
    public static Result<T> Fail(string error, ErrorType errorType) => new
    (
        false,
        default!,
        error,
        errorType
    );
}