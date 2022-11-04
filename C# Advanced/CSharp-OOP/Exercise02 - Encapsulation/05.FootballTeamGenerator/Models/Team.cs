using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            this.Players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EMPTY_NAME);
                }

                this.name = value;
            }
        }

        public List<Player> Players
        {
            get => this.players;
            private set => this.players = value;
        }

        public int Rating => this.players.Count > 0 ? (int)Math.Round(players.Average(p => p.OverallRating) , 0) : 0;

        public void AddPLayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = Players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PLAYER_DOES_NOT_EXIST, playerName, this.Name));
            }

            this.Players.Remove(playerToRemove);
        }

        public override string ToString() => $"{this.Name} - {this.Rating}";
    }
}
