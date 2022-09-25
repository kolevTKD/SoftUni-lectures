using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class SetsOfElements
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int set1Length = dimensions[0];
            int set2Length = dimensions[1];
            HashSet<string> firstElements = new HashSet<string>();
            HashSet<string> secondElements = new HashSet<string>();

            for (int i = 0; i < set1Length + set2Length; i++)
            {
                string element = Console.ReadLine();

                if (i >= set1Length)
                {
                    secondElements.Add(element);
                    continue;
                }

                firstElements.Add(element);
            }
            firstElements.IntersectWith(secondElements);

            Console.WriteLine($"{string.Join(' ', firstElements)}");
        }
    }
}
