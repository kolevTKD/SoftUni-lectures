using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Largest3Numbers
{
    internal class Largest3Numbers
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            List<int> top3Nums = new List<int>(nums.OrderByDescending(x => x).Take(3));
            Console.WriteLine(String.Join(' ', top3Nums));
        }
    }
}
