using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            Cars = new List<Car>();
            Capacity = capacity;
        }

        public List<Car> Cars { get { return this.cars; } set { this.cars = value; } }
        public int Capacity { get { return this.capacity; } set { this.capacity = value; } }
        public int Count { get { return Cars.Count; } }

        public string AddCar(Car car)
        {
            string result = string.Empty;
            if (Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                result = "Car with that registration number, already exists!";
            }

            else if (Capacity == Cars.Count)
            {
                result = "Parking is full!";
            }

            else
            {
                Cars.Add(car);
                result = $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

            return result;
        }

        public string RemoveCar(string registrationNumber)
        {
            string result = string.Empty;
            if (Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                Car carToRemove = Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
                Cars.Remove(carToRemove);
                result = $"Successfully removed {registrationNumber}";
            }

            else
            {
                result = "Car with that registration number, doesn't exist!";
            }

            return result;
        }

        public Car GetCar(string registrationNumber)
        {
            return
                Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            for (int i = 0; i < registrationNumbers.Count; i++)
            {
                Car carToRemove = Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumbers[i]);

                if (carToRemove != default(Car))
                {
                    Cars.Remove(carToRemove);
                }
            }
        }
    }
}
