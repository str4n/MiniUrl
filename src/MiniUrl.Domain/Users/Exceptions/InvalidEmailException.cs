using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Domain.Users.Exceptions;

internal sealed class InvalidEmailException : ApiException
{
    public InvalidEmailException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}