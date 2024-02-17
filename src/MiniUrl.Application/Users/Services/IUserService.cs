using MiniUrl.Application.Users.Requests;

namespace MiniUrl.Application.Users.Services;

public interface IUserService
{
    public Task SignUp(SignUpRequest request);
}