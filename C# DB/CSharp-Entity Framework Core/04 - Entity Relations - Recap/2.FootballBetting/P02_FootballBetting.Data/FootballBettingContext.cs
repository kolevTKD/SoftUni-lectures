namespace P02_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;

    using Common;
    using Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Bet> Bets { get; set; } = null!;
        public DbSet<Color> Colors { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;
        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<Team> Teams { get; set; } = null!;
        public DbSet<Town> Towns { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>(ps =>
            {
                ps.HasKey(ps => new { ps.GameId, ps.PlayerId });

                ps.HasOne(ps => ps.Game)
                .WithMany(ps => ps.PlayersStatistics)
                .HasForeignKey(ps => ps.GameId);

                ps.HasOne(ps => ps.Player)
                .WithMany(ps => ps.PlayersStatistics)
                .HasForeignKey(ps => ps.PlayerId);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity
                    .HasOne(t => t.PrimaryKitColor)
                    .WithMany(c => c.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(t => t.SecondaryKitColor)
                    .WithMany(c => c.SecondaryKitTeams)
                    .HasForeignKey(t => t.SecondaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity
                    .HasOne(g => g.HomeTeam)
                    .WithMany(t => t.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity
                    .HasOne(g => g.AwayTeam)
                    .WithMany(t => t.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity
                    .HasOne(p => p.Town)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TownId)
                    .OnDelete(DeleteBehavior.NoAction);

                //entity
                //    .HasMany(p => p.PlayersStatistics)
                //    .WithOne(ps => ps.Player)
                //    .HasForeignKey(p => p.PlayerId)
                //    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
