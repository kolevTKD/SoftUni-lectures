namespace VehiclesExtension.Exceptions
{
    using System;

    public class InsufficientFuelAmountException : Exception
    {
        private const string INSUFFICIENT_FUEL_AMOUNT = "Cannot fit {0} fuel in the tank";

        public InsufficientFuelAmountException()
            : base(INSUFFICIENT_FUEL_AMOUNT) //MOJE DA GRUMNE TUKA
        {
        }

        public InsufficientFuelAmountException(string message)
            : base(message)
        {
        }
    }
}
