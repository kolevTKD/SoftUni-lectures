using WildFarm.Models.Contracts;

namespace WildFarm.Factories.Contracts
{
    public interface IFoodFactory
    {
        IFood CreateFood(string[] foodArgs);
    }
}
