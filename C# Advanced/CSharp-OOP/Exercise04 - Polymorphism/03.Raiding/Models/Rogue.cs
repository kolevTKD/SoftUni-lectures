namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public const int BASE_POWER = 80;
        public Rogue(string heroName, string heroType)
            : base(heroName, heroType, BASE_POWER)
        {
        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
    }
}
