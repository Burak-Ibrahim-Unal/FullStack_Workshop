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

        public BaseDbContext()
        {
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
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<District> Districts { get; set; }

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

            //tüm tablolarda delete yapılınca cascade yapılmamasını sağlar:
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.NoAction;
            //}

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
                c.Property(p => p.IsFixed).HasColumnName("IsFixed").HasDefaultValue(false);
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

            modelBuilder.Entity<RentalOffice>(rentalOffice =>
            {
                rentalOffice.ToTable("RentalOffices").HasKey(k => k.Id);
                rentalOffice.Property(r => r.Id).HasColumnName("Id");
                rentalOffice.Property(r => r.DistrictId).HasColumnName("DistrictId");

                rentalOffice.HasMany(r => r.Cars);
                rentalOffice.HasOne(r => r.Districts);
            });

            modelBuilder.Entity<Country>(country =>
            {
                country.ToTable("Countries").HasKey(k => k.Id);
                country.Property(p => p.Id).HasColumnName("Id");
                country.Property(p => p.Name).HasColumnName("Name");

                country.HasMany(p => p.Provinces);
            });

            modelBuilder.Entity<Province>(province =>
            {
                province.ToTable("Provinces").HasKey(k => k.Id);
                province.Property(p => p.Id).HasColumnName("Id");
                province.Property(p => p.Name).HasColumnName("Name");
                province.Property(p => p.CountryId).HasColumnName("CountryId");

                province.HasOne(p => p.Country);
            });

            modelBuilder.Entity<District>(district =>
            {
                district.ToTable("Districts").HasKey(k => k.Id);
                district.Property(p => p.Id).HasColumnName("Id");
                district.Property(p => p.Name).HasColumnName("Name");
                district.Property(p => p.ProvinceId).HasColumnName("ProvinceId");

                district.HasOne(p => p.Province);
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
            var car1 = new Car(1, 1, 1, 1, CarState.Available, 100000, 2015, "05avv05", 1500);
            var car2 = new Car(2, 2, 1, 2, CarState.Rented, 200000, 2014, "05abb06", 1300);
            var car3 = new Car(3, 1, 1, 1, CarState.Rented, 300000, 2009, "05acc12", 1400);
            var car4 = new Car(4, 3, 2, 3, CarState.Maintenance, 300000, 2018, "05acd033", 1400);
            var car5 = new Car(5, 4, 4, 4, CarState.Available, 300000, 2016, "05acd036", 1450);
            modelBuilder.Entity<Car>().HasData(car1, car2, car3, car4, car5);


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
            modelBuilder.Entity<FindeksCreditRate>().HasData(new FindeksCreditRate(1, 3, 1480));
            modelBuilder.Entity<FindeksCreditRate>().HasData(new FindeksCreditRate(2, 3, 1300));
            modelBuilder.Entity<FindeksCreditRate>().HasData(new FindeksCreditRate(3, 1, 1150));
            modelBuilder.Entity<FindeksCreditRate>().HasData(new FindeksCreditRate(4, 2, 1600));

            // Seed RentalOffice
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(1, 6));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(2, 15));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(3, 25));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(4, 35));
            modelBuilder.Entity<RentalOffice>().HasData(new RentalOffice(5, 45));

            // Seed OperationClaim
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(1, "admin"));
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(2, "moderator"));
            modelBuilder.Entity<OperationClaim>().HasData(new OperationClaim(3, "user"));

            // Seed Countries
            modelBuilder.Entity<Country>().HasData(new Country(1, "Turkey"));

            // Seed Provinces
            #region enum test
            //int provincesCounter = 1;

            //foreach (City city in (City[])Enum.GetValues(typeof(City)))
            //{
            //    modelBuilder.Entity<Country>().HasData(new Country(provincesCounter++, city.ToString()));
            //} 
            #endregion

            modelBuilder.Entity<Province>().HasData(new Province(1, "Adana", 1));
            modelBuilder.Entity<Province>().HasData(new Province(2, "Adıyaman", 1));
            modelBuilder.Entity<Province>().HasData(new Province(3, "Afyonkarahisar", 1));
            modelBuilder.Entity<Province>().HasData(new Province(4, "Ağrı", 1));
            modelBuilder.Entity<Province>().HasData(new Province(5, "Amasya", 1));
            modelBuilder.Entity<Province>().HasData(new Province(6, "Ankara", 1));
            modelBuilder.Entity<Province>().HasData(new Province(7, "Antalya", 1));
            modelBuilder.Entity<Province>().HasData(new Province(8, "Artvin", 1));
            modelBuilder.Entity<Province>().HasData(new Province(9, "Aydın", 1));
            modelBuilder.Entity<Province>().HasData(new Province(10, "Balıkesir", 1));
            modelBuilder.Entity<Province>().HasData(new Province(11, "Bilecik", 1));
            modelBuilder.Entity<Province>().HasData(new Province(12, "Bingöl", 1));
            modelBuilder.Entity<Province>().HasData(new Province(13, "Bitlis", 1));
            modelBuilder.Entity<Province>().HasData(new Province(14, "Bolu", 1));
            modelBuilder.Entity<Province>().HasData(new Province(15, "Burdur", 1));
            modelBuilder.Entity<Province>().HasData(new Province(16, "Bursa", 1));
            modelBuilder.Entity<Province>().HasData(new Province(17, "Çanakkale", 1));
            modelBuilder.Entity<Province>().HasData(new Province(18, "Çankırı", 1));
            modelBuilder.Entity<Province>().HasData(new Province(19, "Çorum", 1));
            modelBuilder.Entity<Province>().HasData(new Province(20, "Denizli", 1));
            modelBuilder.Entity<Province>().HasData(new Province(21, "Diyarbakır", 1));
            modelBuilder.Entity<Province>().HasData(new Province(22, "Edirne", 1));
            modelBuilder.Entity<Province>().HasData(new Province(23, "Elazığ", 1));
            modelBuilder.Entity<Province>().HasData(new Province(24, "Erzincan", 1));
            modelBuilder.Entity<Province>().HasData(new Province(25, "Erzurum", 1));
            modelBuilder.Entity<Province>().HasData(new Province(26, "Eskişehir", 1));
            modelBuilder.Entity<Province>().HasData(new Province(27, "Gaziantep", 1));
            modelBuilder.Entity<Province>().HasData(new Province(28, "Giresun", 1));
            modelBuilder.Entity<Province>().HasData(new Province(29, "Gümüşhane", 1));
            modelBuilder.Entity<Province>().HasData(new Province(30, "Hakkari", 1));
            modelBuilder.Entity<Province>().HasData(new Province(31, "Hatay", 1));
            modelBuilder.Entity<Province>().HasData(new Province(32, "Isparta", 1));
            modelBuilder.Entity<Province>().HasData(new Province(33, "Mersin", 1));
            modelBuilder.Entity<Province>().HasData(new Province(34, "İstanbul", 1));
            modelBuilder.Entity<Province>().HasData(new Province(35, "İzmir", 1));
            modelBuilder.Entity<Province>().HasData(new Province(36, "Kars", 1));
            modelBuilder.Entity<Province>().HasData(new Province(37, "Kastamonu", 1));
            modelBuilder.Entity<Province>().HasData(new Province(38, "Kayseri", 1));
            modelBuilder.Entity<Province>().HasData(new Province(39, "Kırklareli", 1));
            modelBuilder.Entity<Province>().HasData(new Province(40, "Kırşehir", 1));
            modelBuilder.Entity<Province>().HasData(new Province(41, "Kocaeli", 1));
            modelBuilder.Entity<Province>().HasData(new Province(42, "Konya", 1));
            modelBuilder.Entity<Province>().HasData(new Province(43, "Kütahya", 1));
            modelBuilder.Entity<Province>().HasData(new Province(44, "Malatya", 1));
            modelBuilder.Entity<Province>().HasData(new Province(45, "Manisa", 1));
            modelBuilder.Entity<Province>().HasData(new Province(46, "Kahramanmaraş", 1));
            modelBuilder.Entity<Province>().HasData(new Province(47, "Mardin", 1));
            modelBuilder.Entity<Province>().HasData(new Province(48, "Muğla", 1));
            modelBuilder.Entity<Province>().HasData(new Province(49, "Muş", 1));
            modelBuilder.Entity<Province>().HasData(new Province(50, "Nevşehir", 1));
            modelBuilder.Entity<Province>().HasData(new Province(51, "Niğde", 1));
            modelBuilder.Entity<Province>().HasData(new Province(52, "Ordu", 1));
            modelBuilder.Entity<Province>().HasData(new Province(53, "Rize", 1));
            modelBuilder.Entity<Province>().HasData(new Province(54, "Sakarya", 1));
            modelBuilder.Entity<Province>().HasData(new Province(55, "Samsun", 1));
            modelBuilder.Entity<Province>().HasData(new Province(56, "Siirt", 1));
            modelBuilder.Entity<Province>().HasData(new Province(57, "Sinop", 1));
            modelBuilder.Entity<Province>().HasData(new Province(58, "Sivas", 1));
            modelBuilder.Entity<Province>().HasData(new Province(59, "Tekirdağ", 1));
            modelBuilder.Entity<Province>().HasData(new Province(60, "Tokat", 1));
            modelBuilder.Entity<Province>().HasData(new Province(61, "Trabzon", 1));
            modelBuilder.Entity<Province>().HasData(new Province(62, "Tunceli", 1));
            modelBuilder.Entity<Province>().HasData(new Province(63, "Şanlıurfa", 1));
            modelBuilder.Entity<Province>().HasData(new Province(64, "Uşak", 1));
            modelBuilder.Entity<Province>().HasData(new Province(65, "Van", 1));
            modelBuilder.Entity<Province>().HasData(new Province(66, "Yozgat", 1));
            modelBuilder.Entity<Province>().HasData(new Province(67, "Zonguldak", 1));
            modelBuilder.Entity<Province>().HasData(new Province(68, "Aksaray", 1));
            modelBuilder.Entity<Province>().HasData(new Province(69, "Bayburt", 1));
            modelBuilder.Entity<Province>().HasData(new Province(70, "Karaman", 1));
            modelBuilder.Entity<Province>().HasData(new Province(71, "Kırıkkale", 1));
            modelBuilder.Entity<Province>().HasData(new Province(72, "Batman", 1));
            modelBuilder.Entity<Province>().HasData(new Province(73, "Şırnak", 1));
            modelBuilder.Entity<Province>().HasData(new Province(74, "Bartın", 1));
            modelBuilder.Entity<Province>().HasData(new Province(75, "Ardahan", 1));
            modelBuilder.Entity<Province>().HasData(new Province(76, "Iğdır", 1));
            modelBuilder.Entity<Province>().HasData(new Province(77, "Yalova", 1));
            modelBuilder.Entity<Province>().HasData(new Province(78, "Karabük", 1));
            modelBuilder.Entity<Province>().HasData(new Province(79, "Kilis", 1));
            modelBuilder.Entity<Province>().HasData(new Province(80, "Osmaniye", 1));
            modelBuilder.Entity<Province>().HasData(new Province(81, "Düzce", 1));

            // Seed Districts for ankara,istanbul,izmir
            modelBuilder.Entity<District>().HasData(new District(1, "Altındağ", 6));
            modelBuilder.Entity<District>().HasData(new District(2, "Ayaş", 6));
            modelBuilder.Entity<District>().HasData(new District(3, "Bala", 6));
            modelBuilder.Entity<District>().HasData(new District(4, "Beypazarı", 6));
            modelBuilder.Entity<District>().HasData(new District(5, "Çamlıdere", 6));
            modelBuilder.Entity<District>().HasData(new District(6, "Çankaya", 6));
            modelBuilder.Entity<District>().HasData(new District(7, "Çubuk", 6));
            modelBuilder.Entity<District>().HasData(new District(8, "Elmadağ", 6));
            modelBuilder.Entity<District>().HasData(new District(9, "Güdül", 6));
            modelBuilder.Entity<District>().HasData(new District(10, "Kalecik", 6));
            modelBuilder.Entity<District>().HasData(new District(11, "Kızılcahamam", 6));
            modelBuilder.Entity<District>().HasData(new District(12, "Haymana", 6));
            modelBuilder.Entity<District>().HasData(new District(13, "Nallıhan", 6));
            modelBuilder.Entity<District>().HasData(new District(14, "Polatlı", 6));
            modelBuilder.Entity<District>().HasData(new District(15, "Şereflikoçhisar", 6));
            modelBuilder.Entity<District>().HasData(new District(16, "Yenimahalle", 6));
            modelBuilder.Entity<District>().HasData(new District(17, "Gölbaşı", 6));
            modelBuilder.Entity<District>().HasData(new District(18, "Keçiören", 6));
            modelBuilder.Entity<District>().HasData(new District(19, "Mamak", 6));
            modelBuilder.Entity<District>().HasData(new District(20, "Sincan", 6));
            modelBuilder.Entity<District>().HasData(new District(21, "Kazan", 6));
            modelBuilder.Entity<District>().HasData(new District(22, "Akyurt", 6));
            modelBuilder.Entity<District>().HasData(new District(23, "Etimesgut", 6));
            modelBuilder.Entity<District>().HasData(new District(24, "Evren", 6));
            modelBuilder.Entity<District>().HasData(new District(25, "Pursaklar", 6));
            modelBuilder.Entity<District>().HasData(new District(26, "Adalar", 34));
            modelBuilder.Entity<District>().HasData(new District(27, "Bakırköy", 34));
            modelBuilder.Entity<District>().HasData(new District(28, "Beşiktaş", 34));
            modelBuilder.Entity<District>().HasData(new District(29, "Beykoz", 34));
            modelBuilder.Entity<District>().HasData(new District(30, "Beyoğlu", 34));
            modelBuilder.Entity<District>().HasData(new District(31, "Çatalca", 34));
            modelBuilder.Entity<District>().HasData(new District(32, "Eyüp", 34));
            modelBuilder.Entity<District>().HasData(new District(33, "Fatih", 34));
            modelBuilder.Entity<District>().HasData(new District(34, "Gaziosmanpaşa", 34));
            modelBuilder.Entity<District>().HasData(new District(35, "Kadıköy", 34));
            modelBuilder.Entity<District>().HasData(new District(36, "Kartal", 34));
            modelBuilder.Entity<District>().HasData(new District(37, "Sarıyer", 34));
            modelBuilder.Entity<District>().HasData(new District(38, "Silivri", 34));
            modelBuilder.Entity<District>().HasData(new District(39, "Şile", 34));
            modelBuilder.Entity<District>().HasData(new District(40, "Şişli", 34));
            modelBuilder.Entity<District>().HasData(new District(41, "Üsküdar", 34));
            modelBuilder.Entity<District>().HasData(new District(42, "Zeytinburnu", 34));
            modelBuilder.Entity<District>().HasData(new District(43, "Büyükçekmece", 34));
            modelBuilder.Entity<District>().HasData(new District(44, "Kağıthane", 34));
            modelBuilder.Entity<District>().HasData(new District(45, "Küçükçekmece", 34));
            modelBuilder.Entity<District>().HasData(new District(46, "Pendik", 34));
            modelBuilder.Entity<District>().HasData(new District(47, "Ümraniye", 34));
            modelBuilder.Entity<District>().HasData(new District(48, "Bayrampaşa", 34));
            modelBuilder.Entity<District>().HasData(new District(49, "Avcılar", 34));
            modelBuilder.Entity<District>().HasData(new District(50, "Bağcılar", 34));
            modelBuilder.Entity<District>().HasData(new District(51, "Bahçelievler", 34));
            modelBuilder.Entity<District>().HasData(new District(52, "Güngören", 34));
            modelBuilder.Entity<District>().HasData(new District(53, "Maltepe", 34));
            modelBuilder.Entity<District>().HasData(new District(54, "Sultanbeyli", 34));
            modelBuilder.Entity<District>().HasData(new District(55, "Tuzla", 34));
            modelBuilder.Entity<District>().HasData(new District(56, "Esenler", 34));
            modelBuilder.Entity<District>().HasData(new District(57, "Arnavutköy", 34));
            modelBuilder.Entity<District>().HasData(new District(58, "Ataşehir", 34));
            modelBuilder.Entity<District>().HasData(new District(59, "Başakşehir", 34));
            modelBuilder.Entity<District>().HasData(new District(60, "Beylikdüzü", 34));
            modelBuilder.Entity<District>().HasData(new District(61, "Çekmeköy", 34));
            modelBuilder.Entity<District>().HasData(new District(62, "Esenyurt", 34));
            modelBuilder.Entity<District>().HasData(new District(63, "Sancaktepe", 34));
            modelBuilder.Entity<District>().HasData(new District(64, "Sultangazi", 34));
            modelBuilder.Entity<District>().HasData(new District(65, "Aliağa", 35));
            modelBuilder.Entity<District>().HasData(new District(66, "Bayındır", 35));
            modelBuilder.Entity<District>().HasData(new District(67, "Bergama", 35));
            modelBuilder.Entity<District>().HasData(new District(68, "Bornova", 35));
            modelBuilder.Entity<District>().HasData(new District(69, "Çeşme", 35));
            modelBuilder.Entity<District>().HasData(new District(70, "Dikili", 35));
            modelBuilder.Entity<District>().HasData(new District(71, "Foça", 35));
            modelBuilder.Entity<District>().HasData(new District(72, "Karaburun", 35));
            modelBuilder.Entity<District>().HasData(new District(73, "Karşıyaka", 35));
            modelBuilder.Entity<District>().HasData(new District(74, "Kemalpaşa", 35));
            modelBuilder.Entity<District>().HasData(new District(75, "Kınık", 35));
            modelBuilder.Entity<District>().HasData(new District(76, "Kiraz", 35));
            modelBuilder.Entity<District>().HasData(new District(77, "Menemen", 35));
            modelBuilder.Entity<District>().HasData(new District(78, "Ödemiş", 35));
            modelBuilder.Entity<District>().HasData(new District(79, "Seferihisar", 35));
            modelBuilder.Entity<District>().HasData(new District(80, "Selçuk", 35));
            modelBuilder.Entity<District>().HasData(new District(81, "Tire", 35));
            modelBuilder.Entity<District>().HasData(new District(82, "Torbalı", 35));
            modelBuilder.Entity<District>().HasData(new District(83, "Urla", 35));
            modelBuilder.Entity<District>().HasData(new District(84, "Beydağ", 35));
            modelBuilder.Entity<District>().HasData(new District(85, "Buca", 35));
            modelBuilder.Entity<District>().HasData(new District(86, "Menderes", 35));
            modelBuilder.Entity<District>().HasData(new District(87, "Balçova", 35));
            modelBuilder.Entity<District>().HasData(new District(88, "Çiğli", 35));
            modelBuilder.Entity<District>().HasData(new District(89, "Gaziemir", 35));
            modelBuilder.Entity<District>().HasData(new District(90, "Narlıdere", 35));
            modelBuilder.Entity<District>().HasData(new District(91, "Güzelbahçe", 35));
            modelBuilder.Entity<District>().HasData(new District(92, "Bayraklı", 35));
            modelBuilder.Entity<District>().HasData(new District(93, "Karabağlar", 35));
        }
    }
}
