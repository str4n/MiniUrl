namespace MiniUrl.Api.Endpoints;

internal static class HomeEndpoints
{
    public static IEndpointRouteBuilder MapHomeEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () => "MiniUrl API");

        return app;
    }
}