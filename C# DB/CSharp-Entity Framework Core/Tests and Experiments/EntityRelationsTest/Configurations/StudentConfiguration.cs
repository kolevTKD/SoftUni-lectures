namespace EntityRelationsTest.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using System.Reflection.Emit;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> modelBuilder)
        {
            modelBuilder.HasMany(s => s.Projects)
                .WithOne(p => p.Student)
                .HasForeignKey(p => p.StudentId);

            modelBuilder.HasOne(s => s.Address)
                .WithOne(s => s.Student)
                .HasForeignKey<Address>(a => a.StudentId);
        }
    }
}
