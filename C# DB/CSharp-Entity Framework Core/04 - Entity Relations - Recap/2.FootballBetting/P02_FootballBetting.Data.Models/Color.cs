﻿namespace P02_FootballBetting.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Color
    {
        public Color()
        {
            PrimaryKitTeams = new HashSet<Team>();
            SecondaryKitTeams = new HashSet<Team>();
        }

        [Key]
        public int ColorId { get; set; }
        public string Name { get; set; }

        [InverseProperty(nameof(Team.PrimaryKitColor))]
        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        [InverseProperty(nameof(Team.SecondaryKitColor))]
        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}
