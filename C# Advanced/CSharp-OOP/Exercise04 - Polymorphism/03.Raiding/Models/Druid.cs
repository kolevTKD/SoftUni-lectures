using System;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        public const int BASE_POWER = 80;
        public Druid(string heroName, string heroType)
            : base(heroName, heroType, BASE_POWER)
        {
        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} healed for {base.Power}";
    }
}
