using Application.Features.CourseMatches.Rules;
using Application.Features.Courses.Rules;
using Application.Features.Students.Rules;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.UserService;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Caching;
using Core.ElasticSearch;
using Core.Mailing;
using Core.Mailing.MailkitImplementations;
using Core.Security.Entities;
using Core.Security.Jwt;
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

        services.AddScoped<CourseBusinessRules>();
        services.AddScoped<StudentBusinessRules>();
        services.AddScoped<CourseMatchBusinessRules>();

        services.AddScoped<UserBusinessRules>();
        services.AddScoped<UserOperationClaim>();


        services.AddSingleton<IMailService, MailkitMailService>();
        services.AddSingleton<LoggerServiceBase, FileLogger>();
        services.AddSingleton<IElasticSearch, ElasticSearchManager>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICacheService, CacheService>();
        services.AddScoped<ITokenHelper, JwtHelper>();



        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));// Add all same type service
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));





        return services;
    }
}