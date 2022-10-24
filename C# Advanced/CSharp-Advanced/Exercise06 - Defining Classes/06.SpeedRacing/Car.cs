using System;

namespace _06.SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public string Model { get { return this.model; } set { this.model = value; } }
        public double FuelAmount { get { return this.fuelAmount; } set { this.fuelAmount = value; } }
        public double FuelConsumptionPerKilometer { get { return this.fuelConsumptionPerKilometer; } set { this.fuelConsumptionPerKilometer = value; } }
        public double TravelledDistance { get { return this.travelledDistance; } set { this.travelledDistance = value; } }

        public void Drive(double kilometersToDrive)
        {
            if (kilometersToDrive * this.FuelConsumptionPerKilometer > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }

            else
            {
                this.TravelledDistance += kilometersToDrive;
                this.FuelAmount -= kilometersToDrive * this.FuelConsumptionPerKilometer;
            }
        }
    }
}
