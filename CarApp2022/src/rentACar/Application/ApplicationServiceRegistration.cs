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
using Application.Features.CorporateCustomers.Rules;
using Application.Features.Customers.Rules;
using Application.Features.IndividualCustomers.Rules;
using Application.Features.Invoices.Rules;
using Application.Features.Rentals.Rules;
using Application.Features.Maintenances.Rules;
using Application.Features.FindeksCreditRates.Rules;
using Application.Features.Users.Rules;
using Core.Security.Entities;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddSingleton<LoggerServiceBase, FileLogger>();

        services.AddScoped<BrandBusinessRules>();
        services.AddScoped<ColorBusinessRules>();
        services.AddScoped<CarBusinessRules>();
        services.AddScoped<ModelBusinessRules>();
        services.AddScoped<FuelBusinessRules>();
        services.AddScoped<TransmissionBusinessRules>();
        services.AddScoped<CorporateCustomerBusinessRules>();
        services.AddScoped<CustomerBusinessRules>();
        services.AddScoped<IndividualCustomerBusinessRules>();
        services.AddScoped<ModelBusinessRules>();
        services.AddScoped<RentalBusinessRules>();
        services.AddScoped<InvoiceBusinessRules>();
        services.AddScoped<MaintenanceBusinessRules>();
        services.AddScoped<FindeksCreditRateBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<UserOperationClaim>();



        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>)); // Add all same type service
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));



        return services;
    }
}