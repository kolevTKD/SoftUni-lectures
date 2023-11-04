namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;

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
                optionsBuilder.UseSqlServer("Server=localhost;Database=StudentSystem;Trusted_Connection=True;Trust Server Certificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.HasKey(s => s.StudentId);

                s.Property(s => s.Name)
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar");

                s.Property(s => s.PhoneNumber)
                    .HasMaxLength(10)
                    .HasColumnType("varchar");

                s.HasMany(s => s.Homeworks)
                    .WithOne(s => s.Student)
                    .HasForeignKey(sc => sc.HomeworkId);
            });

            modelBuilder.Entity<Course>(c =>
            {
                c.HasKey(c => c.CourseId);

                c.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnType("nvarchar");

                c.Property(c => c.Description)
                    .HasColumnType("nvarchar");

                c.HasMany(c => c.Resources)
                    .WithOne(c => c.Course)
                    .HasForeignKey(c => c.ResourceId);

                c.HasMany(c => c.Homeworks)
                    .WithOne(c => c.Course)
                    .HasForeignKey(c => c.HomeworkId);
            });

            modelBuilder.Entity<Resource>(r =>
            {
                r.HasKey(r => r.ResourceId);

                r.Property(r => r.Name)
                    .HasMaxLength(50)
                    .HasColumnType("nvarchar");

                r.Property(r => r.Url)
                    .HasColumnType("varchar");

                r.HasOne(r => r.Course)
                    .WithMany(r => r.Resources)
                    .HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(h =>
            {
                h.HasKey(h => h.HomeworkId);

                h.Property(h => h.Content)
                    .HasColumnType("varchar");

                h.HasOne(h => h.Student)
                    .WithMany(h => h.Homeworks)
                    .HasForeignKey(h => h.StudentId);

                h.HasOne(h => h.Course)
                    .WithMany(h => h.Homeworks)
                    .HasForeignKey(h => h.CourseId);
            });

            modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(sc => new { sc.StudentId, sc.CourseId });

                sc.HasOne(sc => sc.Student)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(sc => sc.CourseId);

                sc.HasOne(sc => sc.Course)
                .WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(sc => sc.StudentId);
            });
        }
    }
}
