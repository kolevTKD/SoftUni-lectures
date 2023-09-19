namespace VehiclesExtension.Exceptions
{
    using System;

    public class VehicleNotSupportedException : Exception
    {
        private const string VEHICLE_NOT_SUPPORTED = "Vehicle not supported!";

        public VehicleNotSupportedException()
            : base(VEHICLE_NOT_SUPPORTED)
        {
        }

        public VehicleNotSupportedException(string message)
            : base(message)
        {
        }
    }
}
