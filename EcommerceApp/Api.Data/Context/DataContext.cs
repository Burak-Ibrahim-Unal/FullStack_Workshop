

using Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DataContext()
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    var ConnStr = "Server=localhost;Database=ECommerceApp;Trusted_Connection=true;MultipleAciveResultSets=true";

        //    optionsBuilder.UseSqlServer(ConnStr);
        //}

        public DbSet<Product> Products { get; set; }

    }
}