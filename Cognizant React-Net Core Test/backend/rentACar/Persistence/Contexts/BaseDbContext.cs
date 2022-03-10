using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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

        public DbSet<Car> Cars { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<Location>(location =>
            {
                location.ToTable("Locations").HasKey(k => k.Id);
                location.Property(p => p.Id).HasColumnName("Id");
                location.Property(p => p.Longitude).HasColumnName("Longitude");
                location.Property(p => p.Latitude).HasColumnName("Latitude");


            });


            modelBuilder.Entity<Vehicle>(vehicle =>
            {
                vehicle.ToTable("Vehicles").HasKey(k => k.Id);
                vehicle.Property(p => p.Id).HasColumnName("Id");
                vehicle.Property(p => p.CarId).HasColumnName("CarId");
                vehicle.Property(p => p.YearModel).HasColumnName("YearModel");
                vehicle.Property(p => p.Make).HasColumnName("Make");
                vehicle.Property(p => p.DateAdded).HasColumnName("DateAdded");
                vehicle.Property(p => p.Licensed).HasColumnName("Licensed");
                vehicle.Property(p => p.Model).HasColumnName("Model");
                vehicle.Property(p => p.Price).HasColumnName("Price");

                vehicle.HasOne(p => p.Car);

            });


            modelBuilder.Entity<Warehouse>(warehouse =>
            {
                warehouse.ToTable("Warehouses").HasKey(k => k.Id);
                warehouse.Property(p => p.Id).HasColumnName("Id");
                warehouse.Property(p => p.LocationId).HasColumnName("LocationId");

                warehouse.HasOne(p => p.Location);

            });



            modelBuilder.Entity<Car>(car =>
            {
                car.ToTable("Cars").HasKey(k => k.Id);
                car.Property(p => p.Id).HasColumnName("Id");
                car.Property(p => p.Location).HasColumnName("Location");
                car.Property(p => p.WarehouseId).HasColumnName("WarehouseId");

                car.HasOne(p => p.Warehouse);
                car.HasMany(p => p.Vehicles);

            });



            //Seed Locations
            var Location1 = new Location(1, "47.13111", "-61.54801");
            var Location2 = new Location(2, "15.95386", "7.06246");
            var Location3 = new Location(3, "39.12788", "-2.71398");
            var Location4 = new Location(4, "-70.84354", "132.22345");
            modelBuilder.Entity<Location>().HasData(Location1, Location2, Location3, Location4);



            //Seed Cars
            var Car1 = new Car(1, 1, "West wing");
            var Car2 = new Car(2, 2, "East wing");
            var Car3 = new Car(3, 3, "Suid wing");
            var Car4 = new Car(4, 4, "Suid wing");
            modelBuilder.Entity<Car>().HasData(Car1, Car2, Car3, Car4);


            //Seed Warehouses
            var Warehouse1 = new Warehouse(1, 1, "Warehouse A");
            var Warehouse2 = new Warehouse(2, 2, "Warehouse B");
            var Warehouse3 = new Warehouse(3, 3, "Warehouse C");
            var Warehouse4 = new Warehouse(4, 4, "Warehouse D");
            modelBuilder.Entity<Warehouse>().HasData(Warehouse1, Warehouse2, Warehouse3, Warehouse4);


            // data is read from external console app...
            //var path = @"C:\warehouses.json";
            //string jsonfile = File.ReadAllText(path);
            //Console.WriteLine(jsonfile);
            //IEnumerable<Warehouse> infos = JsonConvert.DeserializeObject<IEnumerable<Warehouse>>(jsonfile);


            Vehicle[] vehicleSeeds = {
                new(1, 1, "Volkswagen", "Jetta III", 1995, 12947.52, true, DateTime.Parse("2018-09-18")),
                new(2, 1, "Chevrolet","Corvette", 2004, 20019.64, true, DateTime.Parse("2018-01-27")),
                new(3, 1, "Ford",  "Expedition EL", 2008, 27323.42, false, DateTime.Parse( "2018-07-03")),
                new(4, 1, "Infiniti",  "FX", 2010, 8541.62, true, DateTime.Parse("2018-03-23")),
                new(5, 1, "GMC",  "Safari", 1998, 14772.5, false, DateTime.Parse( "2018-07-04")),
                new(6, 1, "Plymouth",  "Colt Vista", 1994, 6642.45, true, DateTime.Parse("2018-07-11")),
                new(7, 1, "Cadillac", "Escalade ESV", 2008, 24925.75, false, DateTime.Parse("2018-01-29")),
                new(8, 1, "Mitsubishi", "Pajero", 2002, 28619.45, false, DateTime.Parse("2018-06-12")),
                new(9, 1, "Infiniti", "Q", 1995, 6103.4, false, DateTime.Parse("2017-11-13")),
                new(10, 1, "Ford", "Mustang", 1993, 18992.7, false, DateTime.Parse("2018-01-29")),
                new(11, 1, "Chevrolet", "G-Series 1500", 1997, 23362.41, false, DateTime.Parse("2018-07-30")),
                new(12, 1, "Cadillac", "DeVille", 1993, 18371.53, false, DateTime.Parse("2018-01-24")),
                new(13, 1, "Acura", "NSX", 2001, 23175.76, false, DateTime.Parse("2018-03-28")),
                new(14, 1, "Ford", "Econoline E250", 1994, 26605.54, true, DateTime.Parse("2018-05-13")),
                new(15, 1, "Lexus", "GX", 2005, 27395.26, false, DateTime.Parse("2017-11-12")),
                new(16, 1, "Dodge", "Ram Van 3500", 1999, 6244.51, true, DateTime.Parse("2018-09-28")),
                new(17, 1, "Dodge", "Caravan", 1995, 16145.27, false, DateTime.Parse("2017-11-25")),
                new(18, 1, "Dodge", "Dynasty", 1992, 15103.84, true, DateTime.Parse("2018-08-12")),
                new(19, 1, "Dodge", "Ram 1500", 2004, 9977.65, true, DateTime.Parse("2018-01-18")),
                new(20, 2, "Maserati", "Coupe", 2005, 19957.71, false, DateTime.Parse("2017-11-14")),
                new(21, 2, "Isuzu", "Rodeo", 1998, 6303.99, false, DateTime.Parse("2017-12-03")),
                new(22, 2, "Infiniti", "I", 2002, 6910.16, false, DateTime.Parse("2017-10-15")),
                new(23, 2, "Nissan", "Altima", 1994, 8252.66, false, DateTime.Parse("2018-08-12")),
                new(24, 2, "Toyota", "Corolla", 2009, 23732.11, false, DateTime.Parse("2018-02-13")),
                new(25, 2, "Acura", "MDX", 2011, 8487.19, false, DateTime.Parse("2018-04-18")),
                new(26, 2, "BMW", "7 Series", 1998, 29069.52, false, DateTime.Parse("2017-10-29")),
                new(27, 2, "Nissan", "Maxima", 2004, 11187.68, false, DateTime.Parse("2018-07-16")),
                new(28, 2, "Audi", "A8", 1999, 16047.9, false, DateTime.Parse("2017-12-05")),
                new(29, 2, "Nissan", "Murano", 2005, 25859.78, false, DateTime.Parse("2018-06-06")),
                new(30, 2, "Acura", "RL", 2010, 13232.13, true, DateTime.Parse("2017-12-16")),
                new(31, 2, "Mitsubishi", "Chariot", 1987, 15665.23, false, DateTime.Parse("2018-02-21")),
                new(32, 2, "GMC", "3500 Club Coupe", 1992, 18129.37, true, DateTime.Parse("2018-09-23")),
                new(33, 2, "Dodge", "Dakota", 2009, 14479.37, false, DateTime.Parse("2017-12-12")),
                new(34, 2, "Mercury", "Grand Marquis", 1996, 20614.72, false, DateTime.Parse("2018-05-26")),
                new(35, 2, "Kia", "Sportage", 2001, 27106.47, false, DateTime.Parse("2018-03-14")),
                new(36, 2, "Chevrolet", "Blazer", 1994, 14835.48, false, DateTime.Parse("2017-11-10")),
                new(37, 2, "Mercedes-Benz", "SL-Class", 1994, 27717.28, false, DateTime.Parse("2018-08-17")),
                new(38, 2, "Honda", "Civic Si", 2003, 18569.86, true, DateTime.Parse("2018-09-12")),
                new(39, 2, "Mercedes-Benz", "CL-Class", 2002, 23494.78, true, DateTime.Parse("2018-05-24")),
                new(40, 2, "Volkswagen", "Jetta", 2006, 25469.49, false, DateTime.Parse("2018-04-23")),
                new(41, 2, "Pontiac", "Grand Prix", 1975, 11600.74, true, DateTime.Parse("2018-01-14")),
                new(42, 2, "Infiniti", "FX", 2012, 22000.62, true, DateTime.Parse("2018-06-09")),
                new(43, 2, "Jaguar", "XK", 2006, 10260.79, true, DateTime.Parse("2018-09-28")),
                new(44, 2, "Cadillac", "STS", 2007, 13740.2, false, DateTime.Parse("2018-02-25")),
                new(45, 2, "Pontiac", "Sunfire", 1997, 28489.1, false, DateTime.Parse("2017-12-05")),
                new(46, 2, "Cadillac", "SRX", 2004, 26750.38, true, DateTime.Parse("2018-08-07")),
                new(47, 2, "Land Rover", "Freelander", 2004, 21770.59, false, DateTime.Parse("2018-09-01")),
                new(48, 2, "Suzuki", "Forenza", 2005, 28834.26, false, DateTime.Parse("2018-05-09")),
                new(49, 2, "Saab", "9-7X", 2005, 25975.68, false, DateTime.Parse("2018-06-07")),
                new(50, 2, "Ford", "Fusion", 2012, 28091.96, false, DateTime.Parse("2018-07-15")),
                new(51, 3, "Cadillac",  "Escalade", 2005, 7429.18, true, DateTime.Parse("2018-09-26")),
                new(52, 3, "Porsche", "Cayenne", 2011, 17066.31, true, DateTime.Parse("2017-10-19")),
                new(53, 3, "Mercedes-Benz", "SL-Class", 2005, 14066.06, false, DateTime.Parse("2018-08-08")),
                new(54, 3, "Mitsubishi", "RVR", 1995, 22560.18, false, DateTime.Parse("2018-05-25")),
                new(55, 3, "Volvo", "850", 1995, 25762.08, true, DateTime.Parse("2017-10-03")),
                new(56, 3, "Honda", "del Sol", 1994, 18840.96, true, DateTime.Parse("2017-11-25")),
                new(57, 3, "Infiniti", "Q", 1996, 28773.14, true, DateTime.Parse("2018-08-09")),
                new(58, 3, "Mercedes-Benz", "500E", 1992, 17141.08, true, DateTime.Parse("2018-08-13")),
                new(59, 3, "GMC", "Envoy XL", 2002, 18983.52, true, DateTime.Parse("2018-03-14")),
                new(60, 3, "Volkswagen", "Touareg 2", 2008, 15611.22, true, DateTime.Parse("2018-02-22")),
                new(61, 4, "Saab", "900", 1987, 8771, false, DateTime.Parse("2017-12-01")),
                new(62, 4, "Mazda", "B-Series", 1998, 23407.59, false, DateTime.Parse("2018-03-01")),
                new(63, 4, "GMC", "Sierra 3500", 2012, 5869.23, true, DateTime.Parse("2018-04-27")),
                new(64, 4, "Chevrolet", "Corvette", 1964, 16630.67, true, DateTime.Parse("2018-05-31")),
                new(65, 4, "Toyota", "Tacoma", 1997, 11597.18, false, DateTime.Parse("2018-03-30")),
                new(66, 4, "GMC", "Sonoma", 2004, 18248.21, false, DateTime.Parse("2018-03-09")),
                new(67, 4, "Bugatti", "Veyron", 2009, 8051.64, false, DateTime.Parse("2018-01-10")),
                new(68, 4, "Dodge", "Ram 1500 Club", 1996, 14008.3, false, DateTime.Parse("2018-05-01")),
                new(69, 4, "Land Rover", "Discovery Series II", 2001, 18620.19, false, DateTime.Parse("2018-03-03")),
                new(70, 4, "Volvo", "960", 1993, 7316.93, true, DateTime.Parse("2018-02-15")),
                new(71, 4, "Chrysler", "LHS", 2001, 29444.71, false, DateTime.Parse("2017-10-25")),
                new(72, 4, "Porsche", "944", 1984, 7396.95, true, DateTime.Parse("2017-10-26")),
                new(73, 4, "Subaru", "Legacy", 2010, 24491.8, false, DateTime.Parse("2017-12-26")),
                new(74, 4, "Volvo", "XC90", 2003, 29009.65, true, DateTime.Parse("2018-04-24")),
                new(75, 4, "Buick", "Skyhawk", 1985, 10567.27, false, DateTime.Parse("2018-03-21")),
                new(76, 4, "GMC", "Envoy XUV", 2004, 20997.71, true, DateTime.Parse("2018-03-27")),
                new(77, 4, "Volvo", "S60", 2009, 28614.95, false, DateTime.Parse("2018-07-25")),
                new(78, 4, "Pontiac", "Montana", 2000, 11221.14, false, DateTime.Parse("2018-01-04")),
                new(79, 4, "Lexus", "RX", 2002, 23194.01, false, DateTime.Parse("2018-05-02")),
                new(80, 4, "Lexus", "RX", 2000, 17805.45, false, DateTime.Parse("2018-09-11"))
            };
            modelBuilder.Entity<Vehicle>().HasData(vehicleSeeds);




        }
    }
}
