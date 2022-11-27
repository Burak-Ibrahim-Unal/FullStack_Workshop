using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        //services.AddScoped<BrandBusinessRules>();
        //services.AddScoped<ColorBusinessRules>();
        //services.AddScoped<CarBusinessRules>();
        //services.AddScoped<ModelBusinessRules>();
        //services.AddScoped<FuelBusinessRules>();
        //services.AddScoped<TransmissionBusinessRules>();
        //services.AddScoped<CorporateCustomerBusinessRules>();
        //services.AddScoped<CustomerBusinessRules>();
        //services.AddScoped<IndividualCustomerBusinessRules>();
        //services.AddScoped<ModelBusinessRules>();
        //services.AddScoped<RentalBusinessRules>();
        //services.AddScoped<InvoiceBusinessRules>();
        //services.AddScoped<MaintenanceBusinessRules>();
        //services.AddScoped<FindeksCreditRateBusinessRules>();
        //services.AddScoped<UserBusinessRules>();
        //services.AddScoped<UserOperationClaim>();
        //services.AddScoped<CarDamageBusinessRules>();
        //services.AddScoped<AuthBusinessRules>();


        //services.AddSingleton<IMailService, MailkitMailService>();
        //services.AddSingleton<LoggerServiceBase, FileLogger>();
        //services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        //services.AddScoped<IAuthService, AuthService>();
        //services.AddScoped<IUserService, UserService>();
        //services.AddScoped<ICacheService, CacheService>();


        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));// Add all same type service
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));





        return services;
    }
}