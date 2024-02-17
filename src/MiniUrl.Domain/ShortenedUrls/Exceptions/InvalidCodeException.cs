namespace MiniUrl.Domain.ShortenedUrls.Exceptions;

internal sealed class InvalidCodeException : ApiException
{
    public InvalidCodeException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}