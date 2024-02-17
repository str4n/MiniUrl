using System.Text.RegularExpressions;
using MiniUrl.Application.Users.Exceptions;
using MiniUrl.Application.Users.Requests;
using MiniUrl.Domain.Users.Exceptions;
using MiniUrl.Domain.Users.Repositories;
using MiniUrl.Domain.Users.User;

namespace MiniUrl.Application.Users.Validators;

internal sealed class UserRequestValidator : IUserRequestValidator
{
    private static readonly Regex PasswordRegex = new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");
    private readonly IUserRepository _userRepository;

    public UserRequestValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> Validate(SignUpRequest request)
    {
        var email = (Email)request.Email;
        var username = (Username)request.Username;
        var password = (Password)request.Password;

        if (!PasswordRegex.IsMatch(password))
        {
            throw new InvalidPasswordSyntaxException("Password must contain minimum eight characters, at least one uppercase letter, one lowercase letter, one number and one special character.");
        }

        if (await _userRepository.AnyAsync(email))
        {
            throw new UserAlreadyExistsException($"User with email: {email.Value} already exists");
        }
        
        if (await _userRepository.AnyAsync(username))
        {
            throw new UserAlreadyExistsException($"User with username: {username.Value} already exists");
        }

        return true;
    }
}