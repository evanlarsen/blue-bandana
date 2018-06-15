namespace Lunch.Infrastructure.Exceptions
{
    public class ValidationError
    {
        public readonly string Code;
        public readonly string Message;

        public ValidationError(string code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
