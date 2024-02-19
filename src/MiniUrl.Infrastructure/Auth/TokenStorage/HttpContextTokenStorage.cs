using Microsoft.AspNetCore.Http;

namespace MiniUrl.Infrastructure.Auth.TokenStorage;

internal sealed class HttpContextTokenStorage : ITokenStorage
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string TokenKey = "jwt";
    
    public HttpContextTokenStorage(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void Set(JsonWebToken token) => _httpContextAccessor.HttpContext?.Items.TryAdd(TokenKey, token);

    public JsonWebToken Get()
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            return null;
        }
        
        if (_httpContextAccessor.HttpContext.Items.TryGetValue(TokenKey, out var token))
        {
            return token as JsonWebToken;
        }

        return null;
    }
}