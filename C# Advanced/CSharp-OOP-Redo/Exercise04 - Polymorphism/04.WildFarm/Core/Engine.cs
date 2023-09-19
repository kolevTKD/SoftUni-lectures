namespace WildFarm.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        private Engine()
        {
            animals = new HashSet<IAnimal>();
        }
        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
        }
        public void Run()
        {
            string input = string.Empty;

            while ((input = reader.ReadLine()) != "End")
            {
                ProcessCommand(input);
            }

            PrintAnimals();
        }

        private void ProcessCommand(string input)
        {
            IAnimal animal = null;

            try
            {
                string[] animalInfo = input.Split(' ');
                animal = animalFactory.CreateAnimal(animalInfo);

                string[] foodInfo = reader.ReadLine().Split(' ');
                IFood food = foodFactory.CreateFood(foodInfo);

                writer.WriteLine(animal.ProduceSound());
                animal.Eat(food);

            }
            catch (AnimalTypeNotSupportedException atnse)
            {
                writer.WriteLine(atnse.Message);
            }
            catch (FoodTypeNotSupportedException ftnse)
            {
                writer.WriteLine(ftnse.Message);
            }
            catch (InvalidFoodTypeException ifte)
            {
                writer.WriteLine(ifte.Message);
            }
            catch (Exception)
            {
                throw;
            }

            animals.Add(animal);
        }

        private void PrintAnimals()
        {
            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
    }
}
