using Microsoft.EntityFrameworkCore;
using ShopSmithAPI.Models;

namespace ShopSmithAPI.Data
{
    public class ShopContext : DbContext

    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Labor> Labors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
