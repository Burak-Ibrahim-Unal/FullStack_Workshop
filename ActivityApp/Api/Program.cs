using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<DataContext>(); //Get service of type DataContext from the IServiceProvider. Returns: A service object of type DataContext.
                await context.Database.MigrateAsync(); // Applies any pending migrations for the context to the database. Will create the database if it does not already exist.
                await Seed.SeedData(context); // Applies all seeding data for the context to the database. Will insert the records if it does not already exist.
            }
            catch (Exception e)
            {
                var logger = services.GetRequiredService<Logger<Program>>();
                logger.LogError(e, "Migration Error:" + e.Message);
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
