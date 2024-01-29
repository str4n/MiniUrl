using MiniUrl.Infrastructure.Exceptions;

namespace MiniUrl.Application.Exceptions;

internal sealed class InvalidCodeException : ApiException
{
    public InvalidCodeException(string message) : base(message, ExceptionCategory.ValidationError)
    {
    }
}