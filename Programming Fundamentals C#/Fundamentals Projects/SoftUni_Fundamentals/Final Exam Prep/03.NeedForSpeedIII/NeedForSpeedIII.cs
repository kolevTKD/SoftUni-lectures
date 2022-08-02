using System;
using System.Collections.Generic;

namespace _03.NeedForSpeedIII
{
    class NeedForSpeedIII
    {
        static void Main(string[] args)
        {
            const int TANK_CAPACITY = 75;
            const int NEW_CAR_COND = 100000;
            const int MIN_MILEAGE = 10000;
            int carsCount = int.Parse(Console.ReadLine());
            Dictionary<string, Car> carsInfo = new Dictionary<string, Car>();

            for (int currCar = 1; currCar <= carsCount; currCar++)
            {
                string[] carSpecs = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string carType = carSpecs[0];
                int carMileage = int.Parse(carSpecs[1]);
                int fuelAvalible = int.Parse(carSpecs[2]);

                if (!carsInfo.ContainsKey(carType))
                {
                    Car car = new Car(carMileage, fuelAvalible);
                    carsInfo.Add(carType, car);
                }
            }

            string end = "Stop";
            while (true)
            {
                string[] commands = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == end)
                {
                    break;
                }

                string carType = commands[1];

                switch (command)
                {
                    case "Drive":
                        int distance = int.Parse(commands[2]);
                        int fuel = int.Parse(commands[3]);

                        if (carsInfo[carType].Fuel - fuel < 0)
                        {
                            Console.WriteLine("Not enough fuel to make that ride");
                            continue;
                        }

                        else
                        {
                            carsInfo[carType].CarMileage += distance;
                            carsInfo[carType].Fuel -= fuel;
                            Console.WriteLine($"{carType} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }

                        if (carsInfo[carType].CarMileage >= NEW_CAR_COND)
                        {
                            Console.WriteLine($"Time to sell the {carType}!");
                            carsInfo.Remove(carType);
                        }
                        break;

                    case "Refuel":
                        int fuelToRefill = int.Parse(commands[2]);

                        if (carsInfo[carType].Fuel + fuelToRefill > TANK_CAPACITY)
                        {
                            fuelToRefill = TANK_CAPACITY - carsInfo[carType].Fuel;
                        }

                        carsInfo[carType].Fuel += fuelToRefill;

                        Console.WriteLine($"{carType} refueled with {fuelToRefill} liters");
                        break;

                    case "Revert":
                        int kilometers = int.Parse(commands[2]);
                        carsInfo[carType].CarMileage -= kilometers;

                        if (carsInfo[carType].CarMileage < MIN_MILEAGE)
                        {
                            carsInfo[carType].CarMileage = MIN_MILEAGE;
                            continue;
                        }

                        Console.WriteLine($"{carType} mileage decreased by {kilometers} kilometers");
                        break;
                }
            }

            foreach (var car in carsInfo)
            {
                string carType = car.Key;
                int carMileage = car.Value.CarMileage;
                int carFuel = car.Value.Fuel;

                Console.WriteLine($"{carType} -> Mileage: {carMileage} kms, Fuel in the tank: {carFuel} lt.");
            }
        }
    }

    class Car
    {
        public Car(int mileage, int fuel)
        {
            CarMileage = mileage;
            Fuel = fuel;
        }
        public int CarMileage { get; set; }
        public int Fuel { get; set; }
    }
}
