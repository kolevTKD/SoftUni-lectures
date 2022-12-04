namespace Raiding.Models
{
    using Contracts;
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string heroName, string heroType, int power)
        {
            this.Name = heroName;
            this.Type = heroType;
            this.Power = power;
        }
        public string Name { get; protected set; }
        public string Type { get; protected set; }
        public int Power { get; protected set; }

        public abstract string CastAbility();
    }
}
