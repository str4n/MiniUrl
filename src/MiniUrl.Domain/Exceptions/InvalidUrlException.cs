namespace MiniUrl.Domain.Exceptions;

internal sealed class InvalidUrlException : ApiException
{
    public InvalidUrlException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}