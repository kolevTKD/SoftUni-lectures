using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            SortedDictionary<double, int> numsCount = new SortedDictionary<double, int>();

            foreach(double number in nums)
            {
                if (numsCount.ContainsKey(number))
                {
                    numsCount[number]++;
                    continue;
                }

                numsCount.Add(number, 1);
            }

            foreach (var number in numsCount)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
