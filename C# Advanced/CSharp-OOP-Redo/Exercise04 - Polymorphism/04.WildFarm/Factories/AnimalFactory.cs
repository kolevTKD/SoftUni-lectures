namespace WildFarm.Factories
{
    using Contracts;
    using Exceptions;
    using Models.Animals;
    using Models.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public AnimalFactory()
        {
        }

        public IAnimal CreateAnimal(string[] animalInfo)
        {
            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);
            string mutialArg = animalInfo[3];

            IAnimal animal;

            if (type == "Cat")
            {
                animal = new Cat(name, weight, mutialArg, animalInfo[4]);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, mutialArg, animalInfo[4]);
            }
            else if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(mutialArg));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(mutialArg));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, mutialArg);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, mutialArg);
            }
            else
            {
                throw new AnimalTypeNotSupportedException(string.Format(ExceptionMessages.INVALID_ANIMAL, type));
            }

            return animal;
        }
    }
}
