namespace VehiclesExtension.Exceptions
{
    using System;
    public class InvalidVehicleTypeException : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Vehicle type not supported!";

        public InvalidVehicleTypeException()
            : base(DEFAULT_EXCEPTION_MESSAGE)
        {
        }

        public InvalidVehicleTypeException(string message)
            : base(message)
        {
        }
    }
}
