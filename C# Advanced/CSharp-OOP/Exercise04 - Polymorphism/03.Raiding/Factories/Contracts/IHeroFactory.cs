namespace Raiding.Factories.Contracts
{
    using Models.Contracts;
    public interface IHeroFactory
    {
        IHero CreateHero(string heroName, string heroType);
    }
}
