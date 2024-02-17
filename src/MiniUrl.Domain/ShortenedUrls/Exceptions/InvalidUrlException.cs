namespace MiniUrl.Domain.ShortenedUrls.Exceptions;

internal sealed class InvalidUrlException : ApiException
{
    public InvalidUrlException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}