using APIExample.Models;
using Microsoft.EntityFrameworkCore;

namespace APIExample.Data
{
    public class GenericDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public GenericDbContext(DbContextOptions<GenericDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração específica das entidades, se necessário.
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Order>().ToTable("Orders");

            base.OnModelCreating(modelBuilder);
        }

    }
}
