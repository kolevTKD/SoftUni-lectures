namespace _04.PizzaCalories.Models
{
    public static class ExceptionMessages
    {
        public const string INVALID_TYPE_OF_DOUGH_OR_BAKING_TECHNIQUE = "Invalid type of dough.";
        public const string INVALID_DOUGH_WEIGHT_RANGE = "Dough weight should be in the range [1..200].";
        public const string CANNOT_PLACE_TOPPING_TYPE_ON_PIZZA = "Cannot place {0} on top of your pizza.";
        public const string INVALID_TOPPING_WEIGHT_RANGE = "{0} weight should be in the range [1..50].";
        public const string INVALID_PIZZA_NAME_LENGTH = "Pizza name should be between 1 and 15 symbols.";
        public const string INVALID_TOPPINGS_COUNT = "Number of toppings should be in range [0..10].";
    }
}
