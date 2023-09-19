namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int HERO_POWER = 100;
        public Warrior(string name)
            : base(name, HERO_POWER)
        {
        }

        public override string CastAbility() => $"{base.CastAbility()} hit for {Power} damage";
    }
}
