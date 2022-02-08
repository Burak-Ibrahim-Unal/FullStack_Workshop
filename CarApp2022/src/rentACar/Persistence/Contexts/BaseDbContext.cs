using Domain.Entities;
using Domain.Enums;
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
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }





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
                model.Property(p => p.Name).HasColumnName("Name");
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

                color.HasMany(p => p.Cars);


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
                car.Property(p => p.CarState).HasColumnName("State");

                car.HasOne(p => p.Color);
                car.HasOne(p => p.Model);

            });


            modelBuilder.Entity<Rental>(rental =>
            {
                rental.ToTable("Rentals").HasKey(k => k.Id);
                rental.Property(r => r.Id).HasColumnName("Id");
                rental.Property(r => r.CustomerId).HasColumnName("CustomerId");
                rental.Property(r => r.CarId).HasColumnName("CarId");
                rental.Property(r => r.RentStartDate).HasColumnName("RentStartDate");
                rental.Property(r => r.RentEndDate).HasColumnName("RentEndDate");
                rental.Property(r => r.ReturnDate).HasColumnName("ReturnDate");

                rental.HasOne(r => r.Car);
                rental.HasOne(r => r.Customer);
            });

            modelBuilder.Entity<Customer>(customer =>
            {
                customer.ToTable("Customers").HasKey(c => c.Id);
                customer.Property(c => c.Id).HasColumnName("Id");
                customer.Property(c => c.Email).HasColumnName("Email");

                customer.HasOne(c => c.CorporateCustomer);
                customer.HasOne(c => c.IndividualCustomer);
                customer.HasMany(c => c.Rentals);
                customer.HasMany(c => c.Invoices);

            });


            modelBuilder.Entity<IndividualCustomer>(icustomer =>
            {
                icustomer.ToTable("IndividualCustomers").HasKey(i => i.Id);
                icustomer.Property(i => i.Id).HasColumnName("Id");
                icustomer.Property(i => i.CustomerId).HasColumnName("CustomerId");
                icustomer.Property(i => i.FirstName).HasColumnName("FirstName");
                icustomer.Property(i => i.LastName).HasColumnName("LastName");
                icustomer.Property(i => i.NationalIdentity).HasColumnName("NationalIdentity");

                icustomer.HasOne(i => i.Customer);
            });

            modelBuilder.Entity<CorporateCustomer>(ccustomer =>
            {
                ccustomer.ToTable("CorporateCustomers").HasKey(c => c.Id);
                ccustomer.Property(c => c.Id).HasColumnName("Id");
                ccustomer.Property(c => c.CustomerId).HasColumnName("CustomerId");
                ccustomer.Property(c => c.CompanyName).HasColumnName("CompanyName");
                ccustomer.Property(c => c.TaxNo).HasColumnName("TaxNo");

                ccustomer.HasOne(c => c.Customer);
            });


            modelBuilder.Entity<Invoice>(i =>
            {
                i.ToTable("Invoices").HasKey(i => i.Id);
                i.Property(i => i.Id).HasColumnName("Id");
                i.Property(i => i.CustomerId).HasColumnName("CustomerId");
                i.Property(i => i.No).HasColumnName("No");
                i.Property(i => i.CreatedDate).HasColumnName("CreatedDate").HasDefaultValue(DateTime.Now);
                i.Property(i => i.RentalStartDate).HasColumnName("RentalStartDate");
                i.Property(i => i.RentalEndDate).HasColumnName("RentalEndDate");
                i.Property(i => i.TotalRentalDay).HasColumnName("TotalRentalDay");
                i.Property(i => i.RentalPrice).HasColumnName("RentalPrice");

                i.HasOne(i => i.Customer);
            });


            // Seed Data
            var brand1 = new Brand(1, "renault");
            var brand2 = new Brand(2, "honda");
            modelBuilder.Entity<Brand>().HasData(brand1, brand2);

            var color1 = new Color(1, "red");
            var color2 = new Color(2, "black");
            modelBuilder.Entity<Color>().HasData(color1, color2);

            var transmission1 = new Transmission(1, "manuel");
            var transmission2 = new Transmission(2, "auto");
            modelBuilder.Entity<Transmission>().HasData(transmission1, transmission2);


            var fuel1 = new Fuel(1, "diesel");
            var fuel2 = new Fuel(2, "gasoline");
            modelBuilder.Entity<Fuel>().HasData(fuel1, fuel2);

            var model1 = new Model(1, "kangoo", 500, 1, 1, 1, "");
            var model2 = new Model(2, "civic", 1000, 2, 2, 2, "");
            modelBuilder.Entity<Model>().HasData(model1, model2);


            modelBuilder.Entity<Car>().HasData(new Car(1, 1, 1, "06ABC06", 2012, CarState.Available));
            modelBuilder.Entity<Car>().HasData(new Car(2, 2, 2, "01DEF01", 2015, CarState.Available));


            modelBuilder.Entity<IndividualCustomer>().HasData(new IndividualCustomer(1, 2, "Burak", "Ünal", "3333333331"));
            modelBuilder.Entity<IndividualCustomer>().HasData(new IndividualCustomer(2, 1, "İbrahim", "Ünal", "1333333333"));

            modelBuilder.Entity<CorporateCustomer>().HasData(new CorporateCustomer(1, 2, "Burak Ünal", "123321"));
            modelBuilder.Entity<CorporateCustomer>().HasData(new CorporateCustomer(2, 1, "İbrahim Ünal", "123321"));


            modelBuilder.Entity<Rental>().HasData(new Rental(1, 1, 1, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-2)));
            modelBuilder.Entity<Rental>().HasData(new Rental(2, 1, 1, DateTime.Today.AddDays(-6), DateTime.Today.AddDays(-5), DateTime.Today.AddDays(-1)));


            modelBuilder.Entity<Customer>().HasData(new Customer(1, "burakibrahim@gmail1.com"));
            modelBuilder.Entity<Customer>().HasData(new Customer(2, "burakibrahim@gmail2.com"));


            Invoice[] invoiceSeeds =
{
            new(1, 1, "123123", DateTime.Today, DateTime.Today, DateTime.Today.AddDays(2), 2, 1000),
            new(2, 1, "123123", DateTime.Today, DateTime.Today, DateTime.Today.AddDays(2), 2, 2000)
        };
            //modelBuilder.Entity<Invoice>().HasData(new Invoice(1,1,"123321",DateTime.Now,DateTime.Now,null,));



        }


    }
}
