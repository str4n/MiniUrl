using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniUrl.Infrastructure.CORS;

namespace MiniUrl.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddCorsPolicy(configuration);
        
        return services;
    }

    public static WebApplication UseInfrastructure(this WebApplication app)
    {
        app.UseCorsPolicy();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            // Swagger
        }

        app.UseBlazorFrameworkFiles();
        
        app.MapRazorPages();

        app.MapFallbackToFile("index.html");

        return app;
    }
    
    public static TOptions BindOptions<TOptions>(this IConfigurationSection section) where TOptions : class, new()
    {
        var options = new TOptions();
        section.Bind(options);

        return options;
    }
    
    public static TOptions BindOptions<TOptions>(this IConfiguration configuration, string sectionName) where TOptions : class, new()
        => BindOptions<TOptions>(configuration.GetSection(sectionName));
}