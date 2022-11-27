namespace VehiclesExtension.Exceptions
{
    using System;
    public class VehicleNeedsRefuelingException : Exception
    {
        public VehicleNeedsRefuelingException(string message)
            : base(message)
        {
        }
    }
}
