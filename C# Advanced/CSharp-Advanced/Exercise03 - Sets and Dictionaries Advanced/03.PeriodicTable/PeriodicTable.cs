using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    internal class PeriodicTable
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> periodicElements = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var element in chemicalCompounds)
                {
                    periodicElements.Add(element);
                }
            }

            List<string> chemicalElements = periodicElements.OrderBy(x => x).ToList();
            Console.WriteLine(String.Join(' ', chemicalElements));
        }
    }
}
