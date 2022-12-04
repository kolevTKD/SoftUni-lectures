namespace Raiding.Factories
{
    using Exceptions;
    using Factories.Contracts;
    using Models;
    using Models.Contracts;
    public class HeroFactory : IHeroFactory
    {
        public HeroFactory()
        {
        }

        public IHero CreateHero(string heroName, string heroType)
        {
            IHero hero;

            if (heroType == "Druid")
            {
                hero = new Druid(heroName, heroType);
            }

            else if (heroType == "Paladin")
            {
                hero = new Paladin(heroName, heroType);
            }

            else if (heroType == "Rogue")
            {
                hero = new Rogue(heroName, heroType);
            }

            else if (heroType == "Warrior")
            {
                hero = new Warrior(heroName, heroType);
            }

            else
            {
                throw new InvalidHeroException();
            }

            return hero;
        }
    }
}
