using MiniUrl.Application.Users.Requests;

namespace MiniUrl.Application.Users.Validators;

public interface IUserRequestValidator
{
    public Task<bool> Validate(SignUpRequest request);
}