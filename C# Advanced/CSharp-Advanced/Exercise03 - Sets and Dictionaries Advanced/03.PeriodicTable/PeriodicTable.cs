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
            SortedSet<string> periodicElements = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                periodicElements.UnionWith(chemicalCompounds);
            }

            Console.WriteLine(String.Join(' ', periodicElements));
        }
    }
}
