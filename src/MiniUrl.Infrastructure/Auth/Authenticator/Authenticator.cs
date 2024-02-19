using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MiniUrl.Infrastructure.Time;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MiniUrl.Infrastructure.Auth.Authenticator;

internal sealed class Authenticator : IAuthenticator
{
    private readonly IClock _clock;
    private readonly AuthOptions _options;
    private readonly JwtSecurityTokenHandler _tokenHandler = new();

    public Authenticator(IClock clock, IOptions<AuthOptions> options)
    {
        _clock = clock;
        _options = options.Value;
    }
    
    public JsonWebToken CreateToken(Guid userId, string email)
    {
        var now = _clock.Now();
        var expires = now.Add(_options.Expiry);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
            new(JwtRegisteredClaimNames.Email, userId.ToString())
        };

        var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SigningKey)), 
                SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(_options.Issuer, _options.Audience, claims, now, expires, signingCredentials);

        var accessToken = _tokenHandler.WriteToken(jwt);

        return new JsonWebToken(accessToken);
    }
}