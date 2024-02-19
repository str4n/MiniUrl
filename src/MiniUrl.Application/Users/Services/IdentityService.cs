using System.Text.RegularExpressions;
using MiniUrl.Application.Users.Exceptions;
using MiniUrl.Application.Users.Requests;
using MiniUrl.Application.Users.Validators;
using MiniUrl.Domain.Users.Exceptions;
using MiniUrl.Domain.Users.Repositories;
using MiniUrl.Domain.Users.User;
using MiniUrl.Infrastructure.Auth.Authenticator;
using MiniUrl.Infrastructure.Auth.TokenStorage;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Users.Services;

internal sealed class IdentityService : IIdentityService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRequestValidator _validator;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;
    private readonly ITokenStorage _tokenStorage;
    private readonly IAuthenticator _authenticator;

    public IdentityService(IUserRepository userRepository, IUserRequestValidator validator, IPasswordManager passwordManager, 
        IClock clock, ITokenStorage tokenStorage, IAuthenticator authenticator)
    {
        _userRepository = userRepository;
        _validator = validator;
        _passwordManager = passwordManager;
        _clock = clock;
        _tokenStorage = tokenStorage;
        _authenticator = authenticator;
    }
    
    public async Task SignUp(SignUpRequest request)
    {
        var id = request.Id;
        
        await _validator.Validate(request);

        var securedPassword = _passwordManager.Secure(request.Password);

        var user = new User(request.Email.ToLowerInvariant(), request.Username.ToLowerInvariant(), securedPassword,
            _clock.Now(), id);

        await _userRepository.AddAsync(user);
    }

    public async Task SignIn(SignInRequest request)
    {
        var user = await _userRepository.GetAsync(request.Username);

        if (user is null)
        {
            throw new InvalidCredentialsException();
        }

        if (!_passwordManager.Validate(request.Password, user.Password))
        {
            throw new InvalidCredentialsException();
        }

        if (user.State is UserState.Deleted)
        {
            throw new AccountNotActiveException();
        }

        var jwt = _authenticator.CreateToken(user.Id, user.Email);
        _tokenStorage.Set(jwt);
    }
}