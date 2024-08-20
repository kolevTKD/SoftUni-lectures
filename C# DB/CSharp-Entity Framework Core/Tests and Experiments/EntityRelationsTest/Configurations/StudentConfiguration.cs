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
            modelBuilder.HasKey(s => new { s.Id, s.FacultyNo});
        }
    }
}
