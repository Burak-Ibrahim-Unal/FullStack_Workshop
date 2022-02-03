using System.Reflection;
using Application.Features.Models.Rules;
using Application.Features.Transmissions.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Fuels.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.Brands.Rules;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddScoped<BrandBusinessRules>();
        services.AddScoped<ModelBusinessRules>();
        services.AddScoped<CarBusinessRules>();
        services.AddScoped<FuelBusinessRules>();
        services.AddScoped<TransmissionBusinessRules>();


        return services;
    }
}