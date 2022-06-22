using System;

namespace _01.ComputerStore
{
    class ComputerStore
    {
        static void Main(string[] args)
        {
            double taxes = 0;
            double totalNoTax = 0;
            double total = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "special" || command == "regular")
                {
                    total = totalNoTax + taxes;

                    if (command == "special")
                    {
                        total *= 0.9;
                    }

                    if (total <= 0)
                    {
                        Console.WriteLine("Invalid order!");

                        return;
                    }

                    break;
                }

                double priceNoTax = double.Parse(command);

                if (priceNoTax < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                totalNoTax += priceNoTax;
                taxes += priceNoTax * 0.2;
            }

            Console.WriteLine("Congratulations you've just bought a new computer!");
            Console.WriteLine($"Price without taxes: {totalNoTax:f2}$");
            Console.WriteLine($"Taxes: {taxes:f2}$");
            Console.WriteLine("-----------");
            Console.WriteLine($"Total price: {total:f2}$");
        }
    }
}
