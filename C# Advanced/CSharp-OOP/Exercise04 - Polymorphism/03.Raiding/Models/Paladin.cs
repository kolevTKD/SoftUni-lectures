using System;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public const int BASE_POWER = 100;
        public Paladin(string heroName, string heroType)
            : base(heroName, heroType, BASE_POWER)
        {
        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
    }
}
