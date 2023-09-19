namespace WildFarm.Exceptions
{
    using System;

    public class FoodTypeNotSupportedException : Exception
    {
        private const string FOOD_NOT_SUPPORTED = "{0} is not supported!";
        public FoodTypeNotSupportedException()
            : base(FOOD_NOT_SUPPORTED)
        {
        }
        public FoodTypeNotSupportedException(string message)
            : base(message)
        {
        }
    }
}
