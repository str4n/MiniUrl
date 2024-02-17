using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Domain.ShortenedUrls.Repositories;
using MiniUrl.Infrastructure.EF.Repositories;

namespace MiniUrl.Infrastructure.EF;

internal static class Extensions
{
    private const string SectionName = "Postgres";
    
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        var options = configuration.GetOptions<PostgresOptions>(SectionName);
        services.AddDbContext<MiniUrlDbContext>(x => x.UseNpgsql(options.ConnectionString));

        services.AddScoped<IUrlRepository, UrlRepository>();
        
        return services;
    }
}