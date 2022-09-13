using System;
using System.Collections.Generic;

namespace _06.Supermarket
{
    internal class Supermarket
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Queue<string> customers = new Queue<string>();

            while (name != "End")
            {
                if (name == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                    name = Console.ReadLine();
                    continue;
                }

                customers.Enqueue(name);
                name = Console.ReadLine();
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
