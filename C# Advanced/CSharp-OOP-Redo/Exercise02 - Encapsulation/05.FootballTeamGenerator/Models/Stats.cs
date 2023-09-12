namespace _05.FootballTeamGenerator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;
            private set
            {
                if (IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Endurance)));
                }

                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Endurance)));
                }

                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                if (IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Dribble)));
                }

                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                if (IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Passing)));
                }

                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (IsValidStat(value))
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Shooting)));
                }

                shooting = value;
            }
        }

        private bool IsValidStat(int value) => value < 0 || value > 100;
    }
}
