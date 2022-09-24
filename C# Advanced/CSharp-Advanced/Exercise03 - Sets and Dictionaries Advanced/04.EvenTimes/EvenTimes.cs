using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    internal class EvenTimes
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<int, int> appearances = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!appearances.ContainsKey(number))
                {
                    appearances.Add(number, 0);
                }

                appearances[number]++;
            }

            foreach (var kvp in appearances)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);

                    return;
                }
            }
        }
    }
}
