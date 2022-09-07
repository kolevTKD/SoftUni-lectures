using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._4.MixedUpLists
{
    internal class MixedUpLists
    {
        static void Main(string[] args)
        {
            List<int> line1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> line2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Reverse().ToList();
            List<int> mixedNums = new List<int>();
            int shorter = Math.Min(line1.Count, line2.Count);

            for (int index = 0; index < shorter; index++)
            {
                mixedNums.Add(line1[index]);
                mixedNums.Add(line2[index]);
            }

            mixedNums = mixedNums.OrderBy(x => x).ToList();
            line1.RemoveRange(0, shorter);
            line2.RemoveRange(0, shorter);

            List<int> range = line2;

            if (line1.Count > line2.Count)
            {
                range = line1;
            }

            range.Sort();

            for (int index = 0; index < mixedNums.Count; index++)
            {
                if (mixedNums[index] > range[0] && mixedNums[index] < range[1])
                {
                    Console.Write($"{mixedNums[index]} ");
                }
            }
        }
    }
}
