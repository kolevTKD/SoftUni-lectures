using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    class GaussTrick
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int originalCount = numbers.Count;

            for (int index = 0; index < originalCount / 2; index++)
            {
                numbers[index] += numbers[numbers.Count - 1];
                numbers.Remove(numbers[numbers.Count - 1]);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
