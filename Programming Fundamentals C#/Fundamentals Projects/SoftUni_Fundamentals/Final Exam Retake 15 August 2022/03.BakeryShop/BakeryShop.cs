using System;
using System.Collections.Generic;

namespace _03.BakeryShop
{
    class BakeryShop
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> foodInfo = new Dictionary<string, int>();
            int sold = 0;

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Complete")
                {
                    break;
                }
                string food = commands[2];
                int quantity = int.Parse(commands[1]);

                if (quantity <= 0)
                {
                    continue;
                }

                switch (command)
                {
                    case "Receive":


                        if (!foodInfo.ContainsKey(food))
                        {
                            foodInfo.Add(food, quantity);
                        }

                        else
                        {
                            foodInfo[food] += quantity;
                        }

                        break;

                    case "Sell":

                        if (!foodInfo.ContainsKey(food))
                        {
                            Console.WriteLine($"You do not have any {food}.");
                        }

                        else if (foodInfo.ContainsKey(food))
                        {
                            if (foodInfo[food] < quantity)
                            {
                                Console.WriteLine($"There aren't enough {food}. You sold the last {foodInfo[food]} of them.");
                                sold += foodInfo[food];
                                foodInfo[food] -= quantity;
                            }

                            else
                            {
                                Console.WriteLine($"You sold {quantity} {food}.");
                                foodInfo[food] -= quantity;
                                sold += quantity;
                            }

                            if (foodInfo[food] <= 0)
                            {
                                foodInfo.Remove(food);
                            }
                        }
                        break;
                }
            }

            foreach (var meal in foodInfo)
            {
                Console.WriteLine($"{meal.Key}: {meal.Value}");
            }

            Console.WriteLine($"All sold: {sold} goods");
        }
    }
}
