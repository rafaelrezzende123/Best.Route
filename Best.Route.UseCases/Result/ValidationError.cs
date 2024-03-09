

namespace Best.Route.UseCases.Result
{
    public class ValidationError
    {
        public string Identifier { get; set; }

        public string ErrorMessage { get; set; }

        public string ErrorCode { get; set; }

        public ValidationSeverity Severity { get; set; }

        public ValidationError()
        {
        }

        public ValidationError(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public ValidationError(string identifier, string errorMessage, string errorCode, ValidationSeverity severity)
        {
            Identifier = identifier;
            ErrorMessage = errorMessage;
            ErrorCode = errorCode;
            Severity = severity;
        }
    }
}
