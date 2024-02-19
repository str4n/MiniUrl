using Microsoft.AspNetCore.Mvc;
using MiniUrl.Application.Users.Requests;
using MiniUrl.Application.Users.Services;
using MiniUrl.Infrastructure.Auth.TokenStorage;

namespace MiniUrl.Api.Endpoints;

internal static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/sign-up", SignUp);
        app.MapPost("/sign-in", SignIn);
        
        return app;
    }

    private static async Task<IResult> SignUp([FromBody] SignUpRequest request, [FromServices] IIdentityService identityService)
    {
        var id = Guid.NewGuid();
        
        await identityService.SignUp(request with { Id = id });

        return Results.Ok();
    }

    private static async Task<IResult> SignIn([FromBody] SignInRequest request,
        [FromServices] IIdentityService identityService, [FromServices] ITokenStorage tokenStorage)
    {
        await identityService.SignIn(request);
        var token = tokenStorage.Get();

        return Results.Ok(token);
    }
}