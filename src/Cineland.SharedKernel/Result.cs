namespace Cineland.SharedKernel;

public class Result
{
    public Result(bool isSucess, Error error, object? value)
    {
        if (isSucess && error.ErrorType != ErrorType.None || !isSucess && error.ErrorType == ErrorType.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }

        IsSucess = isSucess;
        Error = error;
        Value = value;
    }

    public bool IsSucess { get; private set; }
    public Error Error { get; private set; }
    public object? Value { get; private set; }

    public bool IsFailure => !IsSucess;

    public bool ContainsValue => Value is not null;

    public static Result Success()
        => new(true, Error.None(), null);

    public static Result Success(object? value)
        => new(true, Error.None(), value);
    
    public static Result Failure(Error error)
        => new(false, error, null);

    public static Result Failure(Error error, object? value)
        => new(false, error, value);
}

public record Error
{
    public Error(string code, string description, ErrorType errorType)
    {
        Code = code;
        Description = description;
        ErrorType = errorType;
    }

    public string Code { get; private set; }
    public string Description { get; private set; }
    public ErrorType ErrorType { get; private set; }

    public static Error None()
        => new(string.Empty, string.Empty, ErrorType.None);
    
    public static Error Failure(string code, string description)
        => new(code, description, ErrorType.Failure);
    
    public static Error Validation(string code, string description)
        => new(code, description, ErrorType.Validation);

    public static Error Problem(string code, string description)
        => new(code, description, ErrorType.Problem);
    
    public static Error NotFound(string code, string description)
        => new(code, description, ErrorType.NotFound);
    
    public static Error Conflict(string code, string description)
        => new(code, description, ErrorType.Conflict);
}

public enum ErrorType
{
    None = 0,
    Failure = 1,
    Validation = 2,
    Problem = 3,
    NotFound = 4,
    Conflict = 5
}