using System.Reflection;
using Application.Features.Transmissions.Rules;
using Application.Features.Cars.Rules;
using Application.Features.Fuels.Rules;
using Application.Features.Models.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Application.Features.Brands.Rules;
using Application.Features.Colors.Rules;
using Core.Application.Pipelines.Validation;
using FluentValidation;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<BrandBusinessRules>();
        services.AddScoped<ColorBusinessRules>();
        services.AddScoped<CarBusinessRules>();
        services.AddScoped<ModelBusinessRules>();
        services.AddScoped<FuelBusinessRules>();
        services.AddScoped<TransmissionBusinessRules>();

        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(RequestValidationBehavior<,>)); // Add all same type service


        return services;
    }
}