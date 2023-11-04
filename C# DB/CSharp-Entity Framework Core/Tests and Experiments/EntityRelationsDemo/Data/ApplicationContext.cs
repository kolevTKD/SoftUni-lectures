using EntityRelationsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityRelationsDemo.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Town> Towns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=EFCoreTableRelations;Trusted_Connection=True;Trust Server Certificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API
            
        }
    }
}
