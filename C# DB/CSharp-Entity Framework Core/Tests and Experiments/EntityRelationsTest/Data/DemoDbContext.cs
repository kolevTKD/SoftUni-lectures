namespace EntityRelationsTest.Data
{
    using EntityRelationsTest.Configurations;
    using EntityRelationsTest.Models;
    using Microsoft.EntityFrameworkCore;

    public class DemoDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=DemoDB;Trusted_Connection=True;Trust Server Certificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
        }
    }
}
