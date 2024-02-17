using Microsoft.Extensions.DependencyInjection;

namespace MiniUrl.Domain.ShortenedUrls;

public static class Extensions
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        return services;
    }
}