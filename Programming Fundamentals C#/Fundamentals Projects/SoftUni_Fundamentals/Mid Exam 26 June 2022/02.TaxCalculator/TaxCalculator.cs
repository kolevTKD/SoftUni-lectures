using System;
using System.Linq;

namespace _02.TaxCalculator
{
    class TaxCalculator
    {
        static void Main(string[] args)
        {
            string[] vehicles = Console.ReadLine().Split(">>").ToArray();
            string carType = "";
            int years = 0;
            int kilometers = 0;
            double decline = 0;
            double initialTax = 0;
            double increase = 0;
            double totalTaxes = 0;

            for (int index = 0; index < vehicles.Length; index++)
            {
                string[] currCar = vehicles[index].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                carType = currCar[0];
                years = int.Parse(currCar[1]);
                kilometers = int.Parse(currCar[2]);
                
                switch (carType)
                {
                    case "family":
                        initialTax = 50;
                        decline = years * 5;
                        increase = kilometers / 3000 * 12;
                        break;

                    case "heavyDuty":
                        initialTax = 80;
                        decline = years * 8;
                        increase = kilometers / 9000 * 14;
                        break;

                    case "sports":
                        initialTax = 100;
                        decline = years * 9;
                        increase = kilometers / 2000 * 18;
                        break;

                    default:
                        Console.WriteLine("Invalid car type.");
                        continue;
                }

                double totalTax = increase + (initialTax - decline);
                totalTaxes += totalTax;
                Console.WriteLine($"A {carType} car will pay {totalTax:f2} euros in taxes.");
            }

            Console.WriteLine($"The National Revenue Agency will collect {totalTaxes:f2} euros in taxes.");
        }
    }
}
