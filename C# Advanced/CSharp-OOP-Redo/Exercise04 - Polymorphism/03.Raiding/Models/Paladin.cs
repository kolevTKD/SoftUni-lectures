namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int HERO_POWER = 100;

        public Paladin(string name)
            : base(name, HERO_POWER)
        {
        }

        public override string CastAbility() => $"{base.CastAbility()} healed for {Power}";
    }
}
