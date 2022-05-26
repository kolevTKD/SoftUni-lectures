using System;

namespace _07_VendingMachine
{
    class VendingMachine
    {
        static void Main(string[] args)
        {
            string command = null;
            string start = "Start";
            string end = "End";
            double totalMoneyInvested = 0;
            double price = 0;
            string nuts = "Nuts";
            string water = "Water";
            string crisps = "Crisps";
            string soda = "Soda";
            string coke = "Coke";

            while (command != start)
            {
                command = Console.ReadLine();

                if (command == start)
                {
                    break;
                }

                double coins = double.Parse(command);

                bool isValidCoin = coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2;

                if (!isValidCoin)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                    continue;
                }

                totalMoneyInvested += coins;
            }

            while (command != end)
            {
                command = Console.ReadLine();

                if (command == end)
                {
                    break;
                }

                string product = command;

                if (product == nuts)
                {
                    price = 2;
                }

                else if (product == water)
                {
                    price = 0.7;
                }

                else if (product == crisps)
                {
                    price = 1.5;
                }

                else if (product == soda)
                {
                    price = 0.8;
                }

                else if (product == coke)
                {
                    price = 1;
                }

                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }


                if (totalMoneyInvested < 0 || price > totalMoneyInvested)
                {
                    Console.WriteLine("Sorry, not enough money");
                    continue;
                }

                else
                {
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }

                totalMoneyInvested -= price;
            }

            Console.WriteLine($"Change: {totalMoneyInvested:f2}");
        }
    }
}
