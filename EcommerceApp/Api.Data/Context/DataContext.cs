using API.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace API.Data.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DataContext()
        {

        }

        public DbSet<Product> Products { get; set; }


    }
}