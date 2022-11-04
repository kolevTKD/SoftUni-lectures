using System;

namespace _05.FootballTeamGenerator.Models
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Endurance)));
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Sprint)));
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Dribble)));
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Passing)));
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;
            private set
            {
                if (IsStatInvalid(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.INVALID_STAT_RANGE, nameof(Shooting)));
                }

                this.shooting = value;
            }
        }

        public bool IsStatInvalid(int value) => value < 0 || value > 100; 
    }
}
