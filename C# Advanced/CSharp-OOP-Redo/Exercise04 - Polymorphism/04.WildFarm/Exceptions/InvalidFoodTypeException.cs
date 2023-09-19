namespace WildFarm.Exceptions
{
    using System;

    public class InvalidFoodTypeException : Exception
    {
        private const string INVALID_FOOD_TYPE = "{0} does not eat {1}!";
        public InvalidFoodTypeException()
            : base(INVALID_FOOD_TYPE)
        {
        }
        public InvalidFoodTypeException(string message)
            : base(message)
        {
        }
    }
}
