using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MiniUrl.Application.Requests;
using MiniUrl.Application.Services;

namespace MiniUrl.Api.Endpoints;

internal static class UrlEndpoints
{
    public static IEndpointRouteBuilder MapUrlEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/", ShortenUrl);
        app.MapGet("{code}", GetRedirection);

        return app;
    }

    private static async Task<IResult> ShortenUrl([FromBody] ShortenUrlRequest request, 
        [FromServices] IUrlService service)
    {
        var result = await service.Shorten(request);

        return Results.Ok(result);
    }

    private static async Task<IResult> GetRedirection([FromRoute] string code, [FromServices] IUrlService service)
    {
        var result = await service.GetUrl(code);

        return Results.Redirect(result.LongUrl);
    }
}