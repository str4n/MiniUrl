using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MiniUrl.Infrastructure.EF;

internal static class Extensions
{
    private const string SectionName = "Postgres";
    
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        
        var options = configuration.GetOptions<PostgresOptions>(SectionName);
        services.AddDbContext<MiniUrlDbContext>(x => x.UseNpgsql(options.ConnectionString));
        
        return services;
    }
}