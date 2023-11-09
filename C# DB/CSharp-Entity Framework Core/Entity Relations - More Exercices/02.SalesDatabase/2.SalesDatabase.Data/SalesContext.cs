namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }
        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(product =>
            {
                product.Property(p => p.Name)
                    .IsUnicode();
            });

            modelBuilder.Entity<Customer>(customer =>
            {
                customer.Property(c => c.Name)
                    .IsUnicode();

                customer.Property(c => c.Email)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Store>(store =>
            {
                store.Property(s => s.Name)
                    .IsUnicode();
            });
        }
    }
}