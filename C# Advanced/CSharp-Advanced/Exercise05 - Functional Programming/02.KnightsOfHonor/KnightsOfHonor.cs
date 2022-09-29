using System;

namespace _02.KnightsOfHonor
{
    internal class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string[], string> print = (names, title) =>
            {
                foreach (string name in names)
                {
                    Console.WriteLine($"{title} {name}");
                }
            };

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            print(names, "Sir");
        }
    }
}
