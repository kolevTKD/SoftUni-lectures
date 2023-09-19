namespace WildFarm.Factories
{
    using Contracts;
    using Exceptions;
    using Models.Contracts;
    using Models.Foods;

    public class FoodFactory : IFoodFactory
    {
        public FoodFactory()
        {
        }

        public IFood CreateFood(string[] foodInfo)
        {
            string foodType = foodInfo[0];
            int quantity = int.Parse(foodInfo[1]);

            IFood food;

            if (foodType == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(quantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else
            {
                throw new FoodTypeNotSupportedException(string.Format(ExceptionMessages.FOOD_NOT_SUPPORTED, foodType));
            }

            return food;
        }
    }
}
