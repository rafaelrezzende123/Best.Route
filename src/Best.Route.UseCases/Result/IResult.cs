namespace Best.Route.UseCases.Result;

public interface IResult
{
    ResultStatus Status { get; }

    IEnumerable<string> Errors { get; }

    List<ValidationError> ValidationErrors { get; }

    Type ValueType { get; }

    object GetValue();
}


