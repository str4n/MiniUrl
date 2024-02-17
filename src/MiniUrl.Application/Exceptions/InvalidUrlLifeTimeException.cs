using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Application.Exceptions;

internal sealed class InvalidUrlLifeTimeException : ApiException
{
    public InvalidUrlLifeTimeException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}