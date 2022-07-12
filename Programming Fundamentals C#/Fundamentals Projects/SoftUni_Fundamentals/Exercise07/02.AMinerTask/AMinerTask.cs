using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    class AMinerTask
    {
        static void Main(string[] args)
        {
            string currOre = Console.ReadLine();
            string end = "stop";
            Dictionary<string, int> oresCount = new Dictionary<string, int>();

            while (currOre != end)
            {
                int count = int.Parse(Console.ReadLine());

                if (!oresCount.ContainsKey(currOre))
                {
                    oresCount.Add(currOre, 0);
                }
                oresCount[currOre] += count;

                currOre = Console.ReadLine();
            }

            foreach (var ore in oresCount)
            {
                Console.WriteLine($"{ore.Key} -> {ore.Value}");
            }
        }
    }
}
