using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MiniUrl.Application.ShortenedUrls.Services;
using MiniUrl.Application.ShortenedUrls.Strategies;
using MiniUrl.Application.Users.Services;
using MiniUrl.Application.Users.Validators;
using MiniUrl.Domain.Users.User;

namespace MiniUrl.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IUrlService, UrlService>();
        services.AddScoped<IUrlCodeGenerator, UrlCodeGenerator>();
        
        services
            .AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>()
            .AddSingleton<IPasswordManager, PasswordManager>();

        services.AddScoped<IUserRequestValidator, UserRequestValidator>();

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddStrategies();
        
        return services;
    }
}