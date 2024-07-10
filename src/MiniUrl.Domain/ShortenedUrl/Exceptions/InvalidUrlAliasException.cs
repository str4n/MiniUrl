using MiniUrl.Domain.Exceptions;

namespace MiniUrl.Domain.ShortenedUrl.Exceptions;

internal sealed class InvalidUrlAliasException : CustomException
{
    public InvalidUrlAliasException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}