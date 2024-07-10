using MiniUrl.Domain.Exceptions;

namespace MiniUrl.Domain.ShortenedUrl.Exceptions;

internal sealed class InvalidUrlException : CustomException
{
    public InvalidUrlException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}