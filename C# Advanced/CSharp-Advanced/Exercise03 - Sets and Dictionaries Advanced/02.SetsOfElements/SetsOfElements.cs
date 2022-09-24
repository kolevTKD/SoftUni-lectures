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
            HashSet<string> firstElements = new HashSet<string>(set1Length);
            HashSet<string> secondElements = new HashSet<string>(set2Length);

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

            HashSet<string> uniques = new HashSet<string>();
            foreach (string element in firstElements)
            {
                if (secondElements.Contains(element))
                {
                    uniques.Add(element);
                }
            }

            Console.WriteLine($"{string.Join(' ', uniques)}");
        }
    }
}
