using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(option =>
                option.UseSqlite(configuration.GetConnectionString("SqliteConnectionString")));



            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();


            return services;
        }

    }
}
