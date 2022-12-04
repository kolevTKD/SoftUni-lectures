namespace WildFarm.Factories
{
    using Contracts;
    using Exceptions;
    using Models.Contracts;
    using Models.Food;

    public class FoodFactory : IFoodFactory
    {
        public FoodFactory()
        {
        }
        public IFood CreateFood(string[] foodArgs)
        {
            string foodType = foodArgs[0];
            int foodQuantity = int.Parse(foodArgs[1]);

            IFood food;

            if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuantity);
            }

            else if (foodType == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }

            else if (foodType == "Meat")
            {
                food = new Meat(foodQuantity);
            }

            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQuantity);
            }

            else
            {
                throw new FoodTypeNotSupportedException();
            }

            return food;
        }
    }
}
