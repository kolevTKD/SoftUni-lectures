
namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_INCREMENT = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption, FUEL_CONSUMPTION_INCREMENT)
        {
        }
    }
}
