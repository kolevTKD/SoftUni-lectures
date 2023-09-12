namespace _05.FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Team
    {
        private string name;
        private List<Player> players;

        private Team()
        {
            Players = new List<Player>();
        }

        public Team(string name)
            : this()
        {
            Name = name;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.INVALID_NAME);
                }

                name = value;
            }
        }
        public List<Player> Players
        {
            get => players;
            private set => players = value;
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = Players.FirstOrDefault(p => p.Name == playerName);

            if (playerToRemove == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.PLAYER_NOT_EXIST, playerName, Name));
            }

            Players.Remove(playerToRemove);
        }
        public int Rating() => Players.Count > 0 ? (int)Math.Round(Players.Average(p => p.OverallSkillLevel()), 0) : 0;

        public override string ToString() => $"{Name} - {Rating()}";
    }
}
