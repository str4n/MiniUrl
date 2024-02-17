using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Domain.Users.Exceptions;

internal sealed class InvalidPasswordSyntaxException : ApiException
{
    public InvalidPasswordSyntaxException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}