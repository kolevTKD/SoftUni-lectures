namespace Raiding.Models.Contracts
{
    public interface IHero
    {
        string Name { get; }
        string Type { get; }
        int Power { get; }

        string CastAbility();
    }
}
