namespace MiniUrl.Domain.Exceptions;

internal sealed class InvalidCodeException : ApiException
{
    public InvalidCodeException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}