using MiniUrl.Domain.ShortenedUrls.Exceptions;

namespace MiniUrl.Domain.Users.Exceptions;

internal sealed class UserAlreadyDeletedException : ApiException
{
    public UserAlreadyDeletedException() : base("User account is already deleted.", ExceptionCategory.BadRequest)
    {
    }
}