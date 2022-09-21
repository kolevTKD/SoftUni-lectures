using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
    internal class CountSameValuesInArray
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> valuesMet = new Dictionary<double, int>();
            double[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => double.Parse(x)).ToArray();

            for (int index = 0; index < values.Length; index++)
            {
                if (!valuesMet.ContainsKey(values[index]))
                {
                    valuesMet.Add(values[index], 0);
                }

                valuesMet[values[index]]++;
            }

            foreach (var value in valuesMet)
            {
                Console.WriteLine($"{value.Key} - {value.Value} times");
            }
        }
    }
}
