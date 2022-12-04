namespace WildFarm.Exceptions
{
    using System;
    public class FoodTypeNotSupportedException : Exception
    {
        public const string FOOD_TYPE_NOT_SUPPORTED_EXCEPTION_MESSAGE = "Food type is not supported!";

        public FoodTypeNotSupportedException()
            : base(FOOD_TYPE_NOT_SUPPORTED_EXCEPTION_MESSAGE)
        {
        }

        public FoodTypeNotSupportedException(string message)
            : base(message)
        {
        }
    }
}
