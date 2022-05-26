using System;

namespace _07.FuelTank
{
    class FuelTank
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double literInTank = double.Parse(Console.ReadLine());
            string diesel = "Diesel";
            string gasoline = "Gasoline";
            string gas = "Gas";
            bool less25 = literInTank < 25;
            bool enough = literInTank >= 25;

            if (fuelType != diesel && fuelType != gasoline && fuelType != gas)
            {
                Console.WriteLine("Invalid fuel!");
            }

            else
            {
                if (less25)
                {
                    Console.WriteLine($"Fill your tank with {fuelType.ToLower()}!");
                }

                else if (enough)
                {
                    Console.WriteLine($"You have enough {fuelType.ToLower()}.");
                }
            }
        }
    }
}
