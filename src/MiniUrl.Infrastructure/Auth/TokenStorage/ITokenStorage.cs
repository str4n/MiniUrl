namespace MiniUrl.Infrastructure.Auth.TokenStorage;

public interface ITokenStorage
{
    void Set(JsonWebToken token);
    JsonWebToken Get();
}