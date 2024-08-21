namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {
        }
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<Homework> Homeworks { get; set; } = null!;
        public DbSet<StudentCourse> StudentsCourses { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.Name)
                .IsUnicode(true);

                entity.Property(s => s.PhoneNumber)
                .IsUnicode(false);

                entity.HasMany(s => s.StudentsCourses)
                .WithOne(sc => sc.Student);

                entity.HasMany(s => s.Homeworks)
                .WithOne(h => h.Student)
                .HasForeignKey(s => s.HomeworkId);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(c => c.Name)
                .IsUnicode(true);

                entity.Property(c => c.Description)
                .IsUnicode(true);

                entity.HasMany(c => c.StudentsCourses)
                .WithOne(sc => sc.Course);

                entity.HasMany(c => c.Resources)
                .WithOne(r => r.Course)
                .HasForeignKey(c => c.ResourceId);

                entity.HasMany(c => c.Homeworks)
                .WithOne(h => h.Course)
                .HasForeignKey(c => c.HomeworkId);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.Property(r => r.Name)
                .IsUnicode(true);

                entity.Property(r => r.Url)
                .IsUnicode(false);

                entity.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(h => h.Content)
                .IsUnicode(false);

                entity.HasOne(s => s.Student)
                .WithMany(s => s.Homeworks);

                entity.HasOne(c => c.Course)
                .WithMany(c => c.Homeworks);
            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new { sc.StudentId, sc.CourseId });

                entity.HasOne(s => s.Student)
                .WithMany(s => s.StudentsCourses)
                .HasForeignKey(s => s.CourseId);

                entity.HasOne(c => c.Course)
                .WithMany(c => c.StudentsCourses)
                .HasForeignKey(c => c.StudentId);
            });
        }
    }
}
