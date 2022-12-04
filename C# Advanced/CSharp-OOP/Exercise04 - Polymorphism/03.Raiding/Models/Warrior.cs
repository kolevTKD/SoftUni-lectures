namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public const int BASE_POWER = 100;
        public Warrior(string heroName, string heroType)
            : base(heroName, heroType, BASE_POWER)
        {
        }

        public override string CastAbility() => $"{this.GetType().Name} - {base.Name} hit for {base.Power} damage";
    }
}
