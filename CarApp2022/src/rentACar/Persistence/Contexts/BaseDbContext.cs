using Core.Security.Entities;
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
        public DbSet<CarDamage> CarDamages { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalOffice> RentalOffices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
        public DbSet<CorporateCustomer> CorporateCustomers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<FindeksCreditRate> FindeksCreditRates { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<User> Users { get; set; }







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
                brand.ToTable("Brands").HasKey(k => k.Id);
                brand.Property(p => p.Id).HasColumnName("Id");
                brand.Property(p => p.Name).HasColumnName("Name");

                brand.HasMany(p => p.Models);


            });

            modelBuilder.Entity<Model>(model =>
            {
                model.ToTable("Models").HasKey(k => k.Id);
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
                color.ToTable("Colors").HasKey(k => k.Id);
                color.Property(p => p.Id).HasColumnName("Id");
                color.Property(p => p.Name).HasColumnName("Name");

                color.HasMany(p => p.Cars);


            });

            modelBuilder.Entity<Fuel>(fuel =>
            {
                fuel.ToTable("Fuels").HasKey(k => k.Id);
                fuel.Property(p => p.Id).HasColumnName("Id");
                fuel.Property(p => p.Name).HasColumnName("Name");

                fuel.HasMany(p => p.Models);


            });

            modelBuilder.Entity<Transmission>(transmission =>
            {
                transmission.ToTable("Transmissions").HasKey(k => k.Id);
                transmission.Property(p => p.Id).HasColumnName("Id");
                transmission.Property(p => p.Name).HasColumnName("Name");

                transmission.HasMany(p => p.Models);


            });

            modelBuilder.Entity<Car>(car =>
            {
                car.ToTable("Cars").HasKey(k => k.Id);
                car.Property(p => p.Id).HasColumnName("Id");
                car.Property(p => p.ColorId).HasColumnName("ColorId");
                car.Property(p => p.ModelId).HasColumnName("ModelId");
                car.Property(p => p.RentalOfficeId).HasColumnName("RentalOfficeId");
                car.Property(p => p.ModelYear).HasColumnName("ModelYear");
                car.Property(p => p.Kilometer).HasColumnName("Kilometer");
                car.Property(p => p.Plate).HasColumnName("Plate");
                car.Property(p => p.CarState).HasColumnName("State");

                car.HasOne(p => p.Color);
                car.HasOne(p => p.Model);
                car.HasMany(p => p.CarDamages);
                car.HasOne(p => p.RentalOffice);


            });


            modelBuilder.Entity<CarDamage>(c =>
            {
                c.ToTable("CarDamages").HasKey(k => k.Id);
                c.Property(p => p.Id).HasColumnName("Id");
                c.Property(p => p.CarId).HasColumnName("CarId");
                c.Property(p => p.IsReady).HasColumnName("IsReady").HasDefaultValue(false);
                c.Property(p => p.Description).HasColumnName("Description");

                c.HasOne(p => p.Car);
            });



            modelBuilder.Entity<Customer>(customer =>
            {
                customer.ToTable("Customers").HasKey(k => k.Id);
                customer.Property(c => c.Id).HasColumnName("Id");
                customer.Property(c => c.ContactEmail).HasColumnName("ContactEmail");
                customer.Property(c => c.ContactNumber).HasColumnName("ContactNumber");

                customer.HasOne(c => c.CorporateCustomer);
                customer.HasOne(c => c.IndividualCustomer);
                customer.HasMany(c => c.Rentals);
                customer.HasMany(c => c.Invoices);

            });


            modelBuilder.Entity<IndividualCustomer>(icustomer =>
            {
                icustomer.ToTable("IndividualCustomers").HasKey(k => k.Id);
                icustomer.Property(i => i.Id).HasColumnName("Id");
                icustomer.Property(i => i.CustomerId).HasColumnName("CustomerId");
                icustomer.Property(i => i.FirstName).HasColumnName("FirstName");
                icustomer.Property(i => i.LastName).HasColumnName("LastName");
                icustomer.Property(i => i.NationalIdentity).HasColumnName("NationalIdentity");

                icustomer.HasOne(i => i.Customer);
            });

            modelBuilder.Entity<CorporateCustomer>(ccustomer =>
            {
                ccustomer.ToTable("CorporateCustomers").HasKey(k => k.Id);
                ccustomer.Property(c => c.Id).HasColumnName("Id");
                ccustomer.Property(c => c.CustomerId).HasColumnName("CustomerId");
                ccustomer.Property(c => c.CompanyName).HasColumnName("CompanyName");
                ccustomer.Property(c => c.TaxNo).HasColumnName("TaxNo");

                ccustomer.HasOne(c => c.Customer);
            });



            modelBuilder.Entity<Rental>(rental =>
            {
                rental.ToTable("Rentals").HasKey(k => k.Id);
                rental.Property(r => r.Id).HasColumnName("Id");
                rental.Property(r => r.CustomerId).HasColumnName("CustomerId");
                rental.Property(r => r.CarId).HasColumnName("CarId");
                rental.Property(r => r.RentalStartOfficeId).HasColumnName("RentalStartOfficeId");
                rental.Property(r => r.RentalEndOfficeId).HasColumnName("RentalEndOfficeId");
                rental.Property(r => r.RentalStartDate).HasColumnName("RentalStartDate");
                rental.Property(r => r.RentalEndDate).HasColumnName("RentalEndDate");
                rental.Property(r => r.ReturnDate).HasColumnName("ReturnDate");
                rental.Property(r => r.RentalStartKilometer).HasColumnName("RentalStartKilometer");
                rental.Property(r => r.RentalEndKilometer).HasColumnName("RentalEndKilometer");

                rental.HasOne(r => r.Car);
                rental.HasOne(r => r.Customer);
                rental.HasOne(r => r.RentalStartOffice);
                rental.HasOne(r => r.RentalEndOffice);
            });

            modelBuilder.Entity<RentalOffice>(rentalOffice =>
            {
                rentalOffice.ToTable("RentalOffices").HasKey(k => k.Id);
                rentalOffice.Property(r => r.Id).HasColumnName("Id");
                rentalOffice.Property(r => r.City).HasColumnName("City");

                rentalOffice.HasMany(r => r.Cars);
            });


            modelBuilder.Entity<FindeksCreditRate>(f =>
            {
                f.ToTable("FindeksCreditRates").HasKey(k => k.Id);
                f.Property(f => f.Id).HasColumnName("Id");
                f.Property(f => f.CustomerId).HasColumnName("CustomerId");
                f.Property(f => f.Score).HasColumnName("Score");

                f.HasOne(f => f.Customer);
            });



            modelBuilder.Entity<Invoice>(i =>
            {
                i.ToTable("Invoices").HasKey(k => k.Id);
                i.Property(i => i.Id).HasColumnName("Id");
                i.Property(i => i.CustomerId).HasColumnName("CustomerId");
                i.Property(i => i.SerialNumber).HasColumnName("SerialNumber");
                i.Property(i => i.CreatedDate).HasColumnName("CreatedDate").HasDefaultValue(DateTime.Now);
                i.Property(i => i.RentalStartDate).HasColumnName("RentalStartDate");
                i.Property(i => i.RentalEndDate).HasColumnName("RentalEndDate");
                i.Property(i => i.TotalRentalDay).HasColumnName("TotalRentalDay");
                i.Property(i => i.RentalPrice).HasColumnName("RentalPrice").HasColumnType("decimal(18,2)");

                i.HasOne(i => i.Customer);
            });

            modelBuilder.Entity<User>(user =>
            {
                user.ToTable("Users").HasKey(u => u.Id);
                user.Property(u => u.Id).HasColumnName("Id");
                user.Property(u => u.FirstName).HasColumnName("FirstName");
                user.Property(u => u.LastName).HasColumnName("LastName");
                user.Property(u => u.Email).HasColumnName("Email");
                user.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt");
                user.Property(u => u.PasswordHash).HasColumnName("PasswordHash");
                user.Property(u => u.Status).HasColumnName("Status").HasDefaultValue(true);
            });

            modelBuilder.Entity<UserOperationClaim>(userOperationClaim =>
            {
                userOperationClaim.ToTable("UserOperationClaims").HasKey(u => u.Id);
                userOperationClaim.Property(u => u.Id).HasColumnName("Id");
                userOperationClaim.Property(u => u.UserId).HasColumnName("UserId");
                userOperationClaim.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId");

                userOperationClaim.HasOne(u => u.User);
                userOperationClaim.HasOne(u => u.OperationClaim);
            });


            // Seed Brands
            var brand1 = new Brand(1, "Renault");
            var brand2 = new Brand(2, "Honda");
            var brand3 = new Brand(3, "Toyota");
            modelBuilder.Entity<Brand>().HasData(brand1, brand2, brand3);




            //Seed Color
            var color1 = new Color(1, "Red");
            var color2 = new Color(2, "Black");
            var color3 = new Color(3, "Blue");
            var color4 = new Color(4, "Gray");
            modelBuilder.Entity<Color>().HasData(color1, color2, color3, color4);


            //Seed Transmissions
            var transmission1 = new Transmission(1, "Manuel");
            var transmission2 = new Transmission(2, "Auto");
            modelBuilder.Entity<Transmission>().HasData(transmission1, transmission2);


            // Seed Fuels
            var fuel1 = new Fuel(1, "Diesel");
            var fuel2 = new Fuel(2, "Gasoline");
            modelBuilder.Entity<Fuel>().HasData(fuel1, fuel2);


            //Seed Models
            var model1 = new Model(1, 1, 1, 1, "Kangoo", 500, "");
            var model2 = new Model(2, 1, 1, 1, "Clio", 600, "");
            var model3 = new Model(3, 2, 2, 1, "Civic", 1000, "");
            var model4 = new Model(4, 2, 2, 2, "Civic", 1200, "");
            var model5 = new Model(5, 1, 3, 1, "Corolla", 1100, "");
            var model6 = new Model(6, 2, 3, 2, "Yaris", 900, "");
            modelBuilder.Entity<Model>().HasData(model1, model2, model3, model4, model5, model6);


            //Seed IndividualCustomer
            modelBuilder.Entity<IndividualCustomer>().HasData(new IndividualCustomer(1, 4, "IndividualCustomer1", "IndividualCustomer1", "3333333331"));
            modelBuilder.Entity<IndividualCustomer>().HasData(new IndividualCustomer(2, 3, "IndividualCustomer2", "IndividualCustomer2", "1333333333"));


            // Seed CorporateCustomer
            modelBuilder.Entity<CorporateCustomer>().HasData(new CorporateCustomer(1, 2, "CorporateCustomer1", "1233213123", ""));
            modelBuilder.Entity<CorporateCustomer>().HasData(new CorporateCustomer(2, 1, "CorporateCustomer2", "1233213214", "ab2"));


            // Seed Customer
            modelBuilder.Entity<Customer>().HasData(new Customer(1, "123456789", "burakibrahim@gmail1.com"));
            modelBuilder.Entity<Customer>().HasData(new Customer(2, "223456781", "burakibrahim@gmail2.com"));
            modelBuilder.Entity<Customer>().HasData(new Customer(3, "323000789", "burakibrahim@gmail3.com"));
            modelBuilder.Entity<Customer>().HasData(new Customer(4, "423666781", "burakibrahim@gmail4.com"));


            // Seed Rentals
            modelBuilder.Entity<Rental>().HasData(new Rental(1, 1, 2, 1, 1, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(5), null, 12300, 13400));
            modelBuilder.Entity<Rental>().HasData(new Rental(2, 3, 1, 2, 1, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), DateTime.Now, 54500, 57100));
            modelBuilder.Entity<Rental>().HasData(new Rental(3, 2, 3, 1, 1, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-10), null, 52300, 53400));
            modelBuilder.Entity<Rental>().HasData(new Rental(4, 4, 1, 2, 1, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), DateTime.Now, 39500, 41400));


            // Seed Cars
            var car1 = new Car(1, 1, 1, 1, CarState.Available, 100000, 2005, "05avv03", 1500);
            var car2 = new Car(2, 2, 1, 2, CarState.Available, 200000, 2004, "05abb03", 1300);
            var car3 = new Car(3, 1, 1, 1, CarState.Available, 300000, 2006, "05acc03", 1400);
            modelBuilder.Entity<Car>().HasData(car1, car2, car3);


            // Seed Car Damages
            var carDamage1 = new CarDamage(1, 1, "Engine Overheat", true);
            var carDamage2 = new CarDamage(2, 3, "Front panel broken", true);
            var carDamage3 = new CarDamage(3, 3, "Engine oil is changed", true);
            var carDamage4 = new CarDamage(4, 2, "Brake pads changed", false);
            modelBuilder.Entity<CarDamage>().HasData(carDamage1, carDamage2, carDamage3, carDamage4);


            // Seed Maintenance
            modelBuilder.Entity<Maintenance>().HasData(new Maintenance(1, "Findshield broken", DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-80), 1));
            modelBuilder.Entity<Maintenance>().HasData(new Maintenance(2, "Front hood rotten", DateTime.Now.AddDays(-60), DateTime.Now.AddDays(-57), 2));
            modelBuilder.Entity<Maintenance>().HasData(new Maintenance(3, "engine overhear", DateTime.Now.AddDays(-45), DateTime.Now.AddDays(-25), 1));



            // Seed  Invoice 
            modelBuilder.Entity<Invoice>().HasData(new Invoice(1, 1, "1233210", DateTime.Now, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(5), 15, 10000));
            modelBuilder.Entity<Invoice>().HasData(new Invoice(2, 3, "2233211", DateTime.Now, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), 9, 4500));
            modelBuilder.Entity<Invoice>().HasData(new Invoice(3, 2, "3233212", DateTime.Now, DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-10), 10, 3600));
            modelBuilder.Entity<Invoice>().HasData(new Invoice(4, 4, "4233213", DateTime.Now, DateTime.Now.AddDays(-6), DateTime.Now.AddDays(-3), 9, 2900));



            // Seed FindeksCreditRate
            modelBuilder.Entity<FindeksCreditRate>().HasData(new FindeksCreditRate(1, 1, 1200));
            modelBuilder.Entity<FindeksCreditRate>().HasData(new FindeksCreditRate(2, 2, 1300));



            // Seed RentalOffice
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(1, City.Ankara, "Mamak"));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(2, City.Ankara, "Kızlay"));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(3, City.Ankara, "Batıken"));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(4, City.İstanbul, "Pendik"));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(5, City.Ankara, "Tandoğan"));



            // Seed OperationClaim
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(1, "admin"));
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(2, "moderator"));
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(3, "user"));







        }


    }
}
