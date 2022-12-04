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
            this.animals = new HashSet<IAnimal>();
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
            string cmd;

            while ((cmd = this.reader.ReadLine()) != "End")
            {
                this.HandleCommand(cmd);
            }

            this.PrintAnimals();
        }

        private void HandleCommand(string command)
        {
            IAnimal animal = null;

            try
            {
                animal = this.CreateAnimalViaFactory(command);
                IFood food = this.CreateFoodViaFactory(command);

                this.writer.WriteLine(animal.ProduceSound());
                animal.Eat(food);
            }
            catch (FoodNotEatenException fnee)
            {
                this.writer.WriteLine(fnee.Message);
            }
            catch(AnimalTypeNotSupportedException atnse)
            {
                this.writer.WriteLine(atnse.Message);
            }
            catch(FoodTypeNotSupportedException ftnse)
            {
                this.writer.WriteLine(ftnse.Message);
            }
            catch (Exception)
            {
                throw;
            }

            animals.Add(animal);

        }

        private IAnimal CreateAnimalViaFactory(string command)
        {
            string[] animalArgs = command.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = this.animalFactory.CreateAnimal(animalArgs);

            return animal;
        }

        private IFood CreateFoodViaFactory(string command)
        {
            string[] foodArgs = this.reader.ReadLine().Split(' ', System.StringSplitOptions.RemoveEmptyEntries);

            IFood food = this.foodFactory.CreateFood(foodArgs);

            return food;
        }

        private void PrintAnimals()
        {
            foreach(IAnimal animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
