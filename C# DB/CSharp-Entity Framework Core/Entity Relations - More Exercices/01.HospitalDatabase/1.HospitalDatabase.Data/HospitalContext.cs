namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Visitation> Visitations { get; set; } = null!;
        public DbSet<Diagnose> Diagnoses { get; set; } = null!;
        public DbSet<Medicament> Medicaments { get; set; } = null!;
        public DbSet<PatientMedicament> PatientsMedicaments { get; set; } = null!;
        public DbSet<Doctor> Doctor { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientMedicament>(pm =>
            {
                pm.HasKey(pm => new { pm.PatientId, pm.MedicamentId });
            });

            modelBuilder.Entity<Patient>(patient =>
            {
                patient.Property(p => p.FirstName)
                    .IsUnicode();

                patient.Property(p => p.LastName)
                    .IsUnicode();

                patient.Property(p => p.Address)
                    .IsUnicode();

                patient.Property(p => p.Email)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visitation>(visitation =>
            {
                visitation.Property(v => v.Comments)
                    .IsUnicode();

                visitation.Property(v => v.PatientId)
                    .HasColumnOrder(5);
            });

            modelBuilder.Entity<Diagnose>(diagnose =>
            {
                diagnose.Property(d => d.Name)
                    .IsUnicode();

                diagnose.Property(d => d.Comments)
                    .IsUnicode();
            });

            modelBuilder.Entity<Medicament>(medicament =>
            {
                medicament.Property(m => m.Name)
                    .IsUnicode();
            });

            modelBuilder.Entity<Doctor>(doctor =>
            {
                doctor.Property(d => d.Name)
                    .IsUnicode();

                doctor.Property(d => d.Specialty)
                    .IsUnicode();
            });
        }
    }
}