using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MiniUrl.Infrastructure.Auth;
using MiniUrl.Infrastructure.Caching;
using MiniUrl.Infrastructure.EF;
using MiniUrl.Infrastructure.Exceptions;
using MiniUrl.Infrastructure.Services;
using MiniUrl.Infrastructure.Time;

namespace MiniUrl.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        
        services.AddScoped<ExceptionHandlerMiddleware>();

        services.AddPostgres(configuration);
        services.AddRedisCaching(configuration);

        services.AddHttpContextAccessor();

        services.AddSingleton<IClock, UtcClock>();
        
        services.AddHostedService<DatabaseInitializer>();
        services.AddHostedService<ExpiredUrlsRemover>();

        services.AddAuth(configuration);

        services.AddSwaggerGen(swagger =>
        {
            swagger.CustomSchemaIds(x => x.FullName);
            swagger.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "MiniUrl API",
                Version = "v1"
            });
        });
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseSwagger();
        app.UseReDoc(options =>
        {
            options.RoutePrefix = "docs";
            options.DocumentTitle = "MiniUrl API";
            options.SpecUrl("/swagger/v1/swagger.json");
        });

        app.UseAuthentication();

        app.UseHttpsRedirection();
        app.UseRouting();

        return app;
    }
    
    internal static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : class, new()
    {
        T options = new T();
        configuration.GetSection(sectionName).Bind(options);

        return options;
    }
}