namespace EntityRelationsTest.Data
{
    using EntityRelationsTest.Configurations;
    using EntityRelationsTest.Models;
    using Microsoft.EntityFrameworkCore;

    public class DemoDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        public DbSet<Lecturer> Lecturers { get; set; } = null!;
        public DbSet<StudentLecturer> StudentLecturer { get; set; } = null!;

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

            modelBuilder.Entity<Address>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Address>()
                .HasOne(a => a.Student)
                .WithOne(a => a.Address)
                .HasForeignKey<Student>(s => s.AddressId);

            modelBuilder.Entity<Lecturer>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<StudentLecturer>()
                .HasKey(sl => new { sl.StudentId, sl.LecturerId });

            modelBuilder.Entity<StudentLecturer>()
                .HasOne(sl => sl.Student)
                .WithMany(sl => sl.StudentLecturer)
                .HasForeignKey(sl => sl.LecturerId);

            modelBuilder.Entity<StudentLecturer>()
                .HasOne(sl => sl.Lecturer)
                .WithMany(sl => sl.StudentLecturer)
                .HasForeignKey(sl => sl.StudentId);
        }
    }
}
