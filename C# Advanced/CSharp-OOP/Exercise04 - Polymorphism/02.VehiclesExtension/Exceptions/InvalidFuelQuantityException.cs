namespace VehiclesExtension.Exceptions
{
    using System;
    public class InvalidFuelQuantityException : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Fuel must be a positive number";

        public InvalidFuelQuantityException()
            : base(DEFAULT_EXCEPTION_MESSAGE)
        {
        }

        public InvalidFuelQuantityException(string message)
            : base(message)
        {
        }
    }
}
