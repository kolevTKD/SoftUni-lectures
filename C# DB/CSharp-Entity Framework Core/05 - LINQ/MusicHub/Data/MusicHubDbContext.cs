namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        DbSet<Song> Songs { get; set; } = null!;
        DbSet<Album> Albums { get; set; } = null!;
        DbSet<Performer> Performers { get; set; } = null!;
        DbSet<Producer> Producers { get; set; } = null!;
        DbSet<Writer> Writers { get; set; } = null!;
        DbSet<SongPerformer> SongsPerformers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(sp =>
            {
                sp.HasKey(sp => new { sp.SongId, sp.PerformerId });
            });
        }
    }
}
