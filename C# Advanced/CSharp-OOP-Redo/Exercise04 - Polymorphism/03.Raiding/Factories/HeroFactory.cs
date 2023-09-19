namespace Raiding.Factories
{
    using Contracts;
    using Exceptions;
    using Models;
    using Models.Contracts;

    public class HeroFactory : IHeroFactory
    {
        public HeroFactory()
        {
        }

        public IBaseHero CreateHero(string name, string type)
        {
            IBaseHero hero;

            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            else
            {
                throw new InvalidHeroException();
            }

            return hero;
        }
    }
}
