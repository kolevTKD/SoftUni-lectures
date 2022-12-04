using WildFarm.Core;
using WildFarm.Factories;
using WildFarm.Factories.Contracts;
using WildFarm.IO;
using WildFarm.IO.Contracts;

namespace WildFarm
{
    public class WildFarmStartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IAnimalFactory animalFactory = new AnimalFactory();
            IFoodFactory foodFactory = new FoodFactory();

            Engine engine = new Engine(reader, writer, animalFactory, foodFactory);
            engine.Run();
        }
    }
}
