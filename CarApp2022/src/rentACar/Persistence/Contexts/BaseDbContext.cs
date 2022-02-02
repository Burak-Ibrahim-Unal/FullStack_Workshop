using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;

        }


        public DbSet<Brand> Brands { get; set; }

        public DbSet<Model> Models { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Fuel> Fuels { get; set; }





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //We took all codes to PersistenceServiceRegistration

            //if (optionsBuilder.IsConfigured)
            //{
            //    base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("RentACarConnectionString")));
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Brand>(brand =>
            {
                brand.ToTable("Brands").HasKey(b => b.Id);
                brand.Property(p => p.Id).HasColumnName("Id");
                brand.Property(p => p.Name).HasColumnName("Name");
                brand.HasMany(p => p.Models);


            });

            modelBuilder.Entity<Model>(model =>
            {
                model.ToTable("Models").HasKey(m => m.Id);
                model.Property(p => p.Id).HasColumnName("Id");
                model.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                model.Property(p => p.BrandId).HasColumnName("BrandId");
                model.Property(p => p.TransmissionId).HasColumnName("TransmissionId");
                model.Property(p => p.FuelId).HasColumnName("FuelId");
                model.Property(p => p.ImageUrl).HasColumnName("ImageUrl");

                model.HasOne(p => p.Brand);
                model.HasOne(p => p.Transmission);
                model.HasOne(p => p.Fuel);
                model.HasMany(p => p.Cars);

            });

            modelBuilder.Entity<Color>(color =>
            {
                color.ToTable("Colors").HasKey(c => c.Id);
                color.Property(p => p.Id).HasColumnName("Id");
                color.Property(p => p.Name).HasColumnName("Name");
                color.HasMany(p => p.Models);


            });

            modelBuilder.Entity<Fuel>(fuel =>
            {
                fuel.ToTable("Fuels").HasKey(f => f.Id);
                fuel.Property(p => p.Id).HasColumnName("Id");
                fuel.Property(p => p.Name).HasColumnName("Name");
                fuel.HasMany(p => p.Models);


            });

            modelBuilder.Entity<Transmission>(transmission =>
            {
                transmission.ToTable("Transmissions").HasKey(t => t.Id);
                transmission.Property(p => p.Id).HasColumnName("Id");
                transmission.Property(p => p.Name).HasColumnName("Name");
                transmission.HasMany(p => p.Models);


            });

            modelBuilder.Entity<Car>(car =>
            {
                car.ToTable("Cars").HasKey(c => c.Id);
                car.Property(p => p.Id).HasColumnName("Id");
                car.Property(p => p.ModelYear).HasColumnName("ModelYear");
                car.Property(p => p.Plate).HasColumnName("Plate");
                car.Property(p => p.ColorId).HasColumnName("ColorId");
                car.Property(p => p.ModelId).HasColumnName("ModelId");

                car.HasOne(p => p.Color);
                car.HasOne(p => p.Model);

            });


        }


    }
}
