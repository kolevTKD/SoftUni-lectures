﻿namespace MusicHub.Data
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

        public DbSet<Album> Albums { get; set; } = null!;
        public DbSet<Performer> Performers { get; set; } = null!;
        public DbSet<Producer> Producers { get; set; } = null!;
        public DbSet<Song> Songs { get; set; } = null!;
        public DbSet<SongPerformer> SongsPerformers { get; set; } = null!;
        public DbSet<Writer> Writers { get; set; } = null!;


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

                sp.HasOne(sp => sp.Song)
                .WithMany(sp => sp.SongPerformers)
                .HasForeignKey(sp => sp.SongId)
                .OnDelete(DeleteBehavior.NoAction);

                sp.HasOne(sp => sp.Performer)
                .WithMany(sp => sp.PerformerSongs)
                .HasForeignKey(sp => sp.PerformerId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            builder.Entity<Song>()
                .Property(s => s.CreatedOn)
                .HasColumnType("date");

            builder.Entity<Album>()
                .Property(a => a.ReleaseDate)
                .HasColumnType("date");
        }
    }
}
