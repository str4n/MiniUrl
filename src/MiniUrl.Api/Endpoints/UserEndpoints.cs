using Microsoft.AspNetCore.Mvc;
using MiniUrl.Application.Users.Requests;
using MiniUrl.Application.Users.Services;

namespace MiniUrl.Api.Endpoints;

internal static class UserEndpoints
{
    public static IEndpointRouteBuilder MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/sign-up", SignUp);
        
        return app;
    }

    public static async Task<IResult> SignUp([FromBody] SignUpRequest request, [FromServices] IUserService userService)
    {
        var id = Guid.NewGuid();
        
        await userService.SignUp(request with { Id = id });

        return Results.Ok();
    }
}