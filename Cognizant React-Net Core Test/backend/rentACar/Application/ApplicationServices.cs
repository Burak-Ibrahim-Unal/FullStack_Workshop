using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Cars.Rules;
using FluentValidation;
using Core.CrossCuttingConcerns.Caching;
using Core.Mailing;
using Core.Mailing.MailkitImplementations;
using Application.Features.Locations.Rules;
using Application.Features.Warehouses.Rules;
using Application.Features.Vehicles.Rules;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            services.AddScoped<CarBusinessRules>();
            services.AddScoped<LocationBusinessRules>();
            services.AddScoped<WarehouseBusinessRules>();
            services.AddScoped<VehicleBusinessRules>();


            services.AddScoped<ICacheService, CacheService>();
            services.AddSingleton<IMailService, MailkitMailService>();
            services.AddSingleton<LoggerServiceBase, FileLogger>();


            return services;

        }
    }
}
