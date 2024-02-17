using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Domain.ShortenedUrls.Repositories;
using MiniUrl.Infrastructure.Caching.Decorators;
using MiniUrl.Infrastructure.EF.Repositories;

namespace MiniUrl.Infrastructure.Caching;

internal static class Extensions
{
    private const string SectionName = "Redis";
    
    public static IServiceCollection AddRedisCaching(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<RedisOptions>(SectionName);
        services.AddStackExchangeRedisCache(r =>
        {
            r.Configuration = options.ConnectionString;
        });

        services.TryDecorate<IUrlRepository, CachedUrlRepository>();
        
        return services;
    }
}