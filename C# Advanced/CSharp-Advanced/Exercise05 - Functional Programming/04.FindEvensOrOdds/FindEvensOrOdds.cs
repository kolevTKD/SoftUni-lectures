using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    internal class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            Predicate<int> even = num => num % 2 == 0;
            Predicate<int> odd = num => num % 2 != 0;

            int[] range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool isEven = Console.ReadLine() == "even";

            List<int> numbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                numbers.Add(i);
            }

            List<int> result = new List<int>();

            if (isEven)
            {
                result = numbers.FindAll(even);
            }

            else
            {
                result = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
