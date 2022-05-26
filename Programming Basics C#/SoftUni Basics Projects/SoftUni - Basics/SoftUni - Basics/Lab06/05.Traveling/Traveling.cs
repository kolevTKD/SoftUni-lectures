using System;

namespace _05.Traveling
{
    class Traveling
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string end = "End";

            while (input != end)
            {
                double price = double.Parse(Console.ReadLine());
                double saved = 0;

                while (price > saved)
                {
                    saved += double.Parse(Console.ReadLine());
                }

                Console.WriteLine($"Going to {input}!");
                input = Console.ReadLine();
            }
        }
    }
}
