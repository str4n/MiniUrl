using System.Text.RegularExpressions;
using MiniUrl.Application.Users.Requests;
using MiniUrl.Application.Users.Validators;
using MiniUrl.Domain.Users.Exceptions;
using MiniUrl.Domain.Users.Repositories;
using MiniUrl.Domain.Users.User;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Application.Users.Services;

internal sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRequestValidator _validator;
    private readonly IPasswordManager _passwordManager;
    private readonly IClock _clock;

    public UserService(IUserRepository userRepository, IUserRequestValidator validator, IPasswordManager passwordManager, IClock clock)
    {
        _userRepository = userRepository;
        _validator = validator;
        _passwordManager = passwordManager;
        _clock = clock;
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
}