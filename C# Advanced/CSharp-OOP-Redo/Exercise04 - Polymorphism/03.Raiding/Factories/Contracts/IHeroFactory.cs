namespace Raiding.Factories.Contracts
{
    using Models.Contracts;

    public interface IHeroFactory
    {
        IBaseHero CreateHero(string name, string type);
    }
}
