namespace Vehicles.Exceptions
{
    using System;

    public class VehicleNeedsRefuelingException : Exception
    {
        private const string VEHICLE_NEEDS_REFUELING = "{0} needs refueling";

        public VehicleNeedsRefuelingException()
            : base(VEHICLE_NEEDS_REFUELING)
        {
        }

        public VehicleNeedsRefuelingException(string message)
            : base(message)
        {
        }
    }
}
