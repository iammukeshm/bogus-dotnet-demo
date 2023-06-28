using Bogus.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Bogus.Demo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //ensures consistent fake data everytime
            Randomizer.Seed = new Random(1);
            modelBuilder
                .Entity<Product>()
                .HasData(Product.Fake().GenerateBetween(10, 10));
        }
    }
}
