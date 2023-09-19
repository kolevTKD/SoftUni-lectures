namespace WildFarm.Exceptions
{
    using System;

    public class AnimalTypeNotSupportedException : Exception
    {
        private const string INVALID_ANIMAL = "{0} not suported!";

        public AnimalTypeNotSupportedException()
            : base(INVALID_ANIMAL)
        {
        }
        public AnimalTypeNotSupportedException(string message)
            : base(message)
        {
        }
    }
}
