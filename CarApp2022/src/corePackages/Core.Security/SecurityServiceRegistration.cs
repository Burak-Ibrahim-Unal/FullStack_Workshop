using Core.Security.Jwt;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
}