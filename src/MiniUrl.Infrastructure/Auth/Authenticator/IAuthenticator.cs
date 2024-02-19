namespace MiniUrl.Infrastructure.Auth.Authenticator;

public interface IAuthenticator
{
    JsonWebToken CreateToken(Guid userId, string email);
}