using Microsoft.EntityFrameworkCore;
using ShopSmithAPI.Models;

namespace ShopSmithAPI.Data
{
    // ShopContext inherits from DbContext - it represents the database context for the application.
    public class ShopContext : DbContext
    {
        // Constructor injection of DbContextOptions (Dependency Inversion Principle)
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        // Protected method to configure the model for the database (Open/Closed Principle).
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the Labor entity's LaborTime property to have a precision of 4 digits with 2 decimal places.
            // This could be considered applying the Open/Closed Principle since it's an extensible way of configuring entity properties.
            modelBuilder.Entity<Labor>()
                .Property(l => l.LaborTime)
                .HasPrecision(4, 2);
        }

        // DbSet properties represent database tables and allow interaction with the entities (Single Responsibility Principle).
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Labor> Labors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
