using System.Text.Json.Serialization;
namespace Best.Route.UseCases.Result;

public class Result<T> : IResult
{
    public T Value { get; }

    [JsonIgnore]
    public Type ValueType => typeof(T);

    public ResultStatus Status { get; protected set; }

    public bool IsSuccess => Status == ResultStatus.Ok;

    public string SuccessMessage { get; protected set; } = string.Empty;


    public string CorrelationId { get; protected set; } = string.Empty;


    public IEnumerable<string> Errors { get; protected set; } = new List<string>();


    public List<ValidationError> ValidationErrors { get; protected set; } = new List<ValidationError>();


    protected Result()
    {
    }

    public Result(T value)
    {
        Value = value;
    }

    protected internal Result(T value, string successMessage)
        : this(value)
    {
        SuccessMessage = successMessage;
    }

    protected Result(ResultStatus status)
    {
        Status = status;
    }

    public static implicit operator T(Result<T> result)
    {
        return result.Value;
    }

    public static implicit operator Result<T>(T value)
    {
        return new Result<T>(value);
    }


    public object GetValue()
    {
        return Value;
    }

    public PagedResult<T> ToPagedResult(PagedInfo pagedInfo)
    {
        return new PagedResult<T>(pagedInfo, Value)
        {
            Status = Status,
            SuccessMessage = SuccessMessage,
            CorrelationId = CorrelationId,
            Errors = Errors,
            ValidationErrors = ValidationErrors
        };
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Success(T value, string successMessage)
    {
        return new Result<T>(value, successMessage);
    }

    public static Result<T> Error(params string[] errorMessages)
    {
        return new Result<T>(ResultStatus.Error)
        {
            Errors = errorMessages
        };
    }

    public static Result<T> Invalid(ValidationError validationError)
    {
        return new Result<T>(ResultStatus.Invalid)
        {
            ValidationErrors = { validationError }
        };
    }

    public static Result<T> Invalid(params ValidationError[] validationErrors)
    {
        return new Result<T>(ResultStatus.Invalid)
        {
            ValidationErrors = new List<ValidationError>(validationErrors)
        };
    }

    public static Result<T> Invalid(List<ValidationError> validationErrors)
    {
        return new Result<T>(ResultStatus.Invalid)
        {
            ValidationErrors = validationErrors
        };
    }

    public static Result<T> NotFound()
    {
        return new Result<T>(ResultStatus.NotFound);
    }

    public static Result<T> NotFound(params string[] errorMessages)
    {
        return new Result<T>(ResultStatus.NotFound)
        {
            Errors = errorMessages
        };
    }

    public static Result<T> Forbidden()
    {
        return new Result<T>(ResultStatus.Forbidden);
    }

    public static Result<T> Unauthorized()
    {
        return new Result<T>(ResultStatus.Unauthorized);
    }

    public static Result<T> Conflict()
    {
        return new Result<T>(ResultStatus.Conflict);
    }

    public static Result<T> Conflict(params string[] errorMessages)
    {
        return new Result<T>(ResultStatus.Conflict)
        {
            Errors = errorMessages
        };
    }

    public static Result<T> CriticalError(params string[] errorMessages)
    {
        return new Result<T>(ResultStatus.CriticalError)
        {
            Errors = errorMessages
        };
    }

    public static Result<T> Unavailable(params string[] errorMessages)
    {
        return new Result<T>(ResultStatus.Unavailable)
        {
            Errors = errorMessages
        };
    }
}
