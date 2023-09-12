namespace _05.FootballTeamGenerator.Models
{
    using System;
    public class Player
    {
        private string name;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
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
        public Stats Stats { get; private set; }

        public double OverallSkillLevel() => (Stats.Endurance + Stats.Sprint + Stats.Dribble + Stats.Passing + Stats.Shooting) / 5.0;
    }
}
