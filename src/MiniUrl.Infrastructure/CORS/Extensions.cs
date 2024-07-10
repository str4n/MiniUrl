using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace MiniUrl.Infrastructure.CORS;

internal static class Extensions
{
    private const string SectionName = "cors";
    private const string PolicyName = "cors";
    
    public static IServiceCollection AddCorsPolicy(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(SectionName);
        services.Configure<CorsOptions>(section);
        var options = section.BindOptions<CorsOptions>();

        if (!options.Enabled)
        {
            return services;
        }

        services.AddCors(cors =>
        {
            cors.AddPolicy(PolicyName, policyBuilder => policyBuilder
                    .WithOrigins(options.AllowedOrigins.ToArray())
                    .WithMethods(options.AllowedMethods.ToArray())
                    .WithHeaders(options.AllowedHeaders.ToArray()));
        });
        
        return services;
    }

    public static IApplicationBuilder UseCorsPolicy(this IApplicationBuilder app)
    {
        var options = app.ApplicationServices.GetRequiredService<IOptions<CorsOptions>>().Value;
        if (!options.Enabled)
        {
            return app;
        }

        app.UseCors(PolicyName);

        return app;
    }
}