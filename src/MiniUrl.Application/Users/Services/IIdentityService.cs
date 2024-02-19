using MiniUrl.Application.Users.Requests;

namespace MiniUrl.Application.Users.Services;

public interface IIdentityService
{
    public Task SignUp(SignUpRequest request);
    public Task SignIn(SignInRequest request);
}