namespace WildFarm.Exceptions
{
    using System;
    public class AnimalTypeNotSupportedException : Exception
    {
        public const string ANIMAL_TYPE_NOT_SUPPORTED_MESSAGE = "Animal type not supported!";

        public AnimalTypeNotSupportedException()
            : base(ANIMAL_TYPE_NOT_SUPPORTED_MESSAGE)
        {
        }

        public AnimalTypeNotSupportedException(string message)
            : base(message)
        {
        }
    }
}
