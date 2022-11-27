namespace VehiclesExtension.Exceptions
{
    using System;
    public class ImmersiveFuelAmountException : Exception
    {
        public ImmersiveFuelAmountException(string message)
            : base(message)
        {
        }
    }
}
