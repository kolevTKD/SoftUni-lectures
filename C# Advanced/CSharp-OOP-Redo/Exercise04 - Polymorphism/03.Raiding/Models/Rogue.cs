namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int HERO_POWER = 80;

        public Rogue(string name)
            : base(name, HERO_POWER)
        {
        }

        public override string CastAbility() => $"{base.CastAbility()} hit for {Power} damage";
    }
}
