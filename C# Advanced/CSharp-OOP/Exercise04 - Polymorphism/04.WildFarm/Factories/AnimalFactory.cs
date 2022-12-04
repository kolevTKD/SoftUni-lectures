namespace WildFarm.Factories
{
    using Contracts;
    using Exceptions;
    using Models.Animal;
    using Models.Contracts;

    public class AnimalFactory : IAnimalFactory
    {
        public AnimalFactory()
        {
        }
        public IAnimal CreateAnimal(string[] animalArgs)
        {
            IAnimal animal;

            string animalType = animalArgs[0];
            string animalName = animalArgs[1];
            double animalWeight = double.Parse(animalArgs[2]);
            string mutualArg = animalArgs[3];

            if (animalType == "Hen")
            {
                animal = new Hen(animalName, animalWeight, double.Parse(mutualArg));
            }

            else if (animalType == "Owl")
            {
                animal = new Owl(animalName, animalWeight, double.Parse(mutualArg));
            }

            else if (animalType == "Mouse")
            {
                animal = new Mouse(animalName, animalWeight, mutualArg);
            }

            else if (animalType == "Dog")
            {
                animal = new Dog(animalName, animalWeight, mutualArg);
            }

            else if (animalType == "Cat")
            {
                animal = new Cat(animalName, animalWeight, mutualArg, animalArgs[4]);
            }

            else if (animalType == "Tiger")
            {
                animal = new Tiger(animalName, animalWeight, mutualArg, animalArgs[4]);
            }

            else
            {
                throw new AnimalTypeNotSupportedException();
            }

            return animal;
        }
    }
}
