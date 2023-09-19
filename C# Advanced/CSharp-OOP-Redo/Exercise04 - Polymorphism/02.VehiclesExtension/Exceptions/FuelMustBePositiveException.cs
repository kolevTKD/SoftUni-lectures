namespace VehiclesExtension.Exceptions
{
    using System;

    public class FuelMustBePositiveException : Exception
    {
        private const string FUEL_MUST_BE_POSITIVE = "Fuel must be a positive number";

        public FuelMustBePositiveException()
            : base(FUEL_MUST_BE_POSITIVE)
        {
        }
        public FuelMustBePositiveException(string message)
            : base(message)
        {
        }
    }
}
