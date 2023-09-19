namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int HERO_POWER = 80;

        public Druid(string name)
            : base(name, HERO_POWER)
        {
        }

        public override string CastAbility() => $"{base.CastAbility()} healed for {Power}";
    }
}
