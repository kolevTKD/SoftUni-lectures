using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class SumAdjacentEqualNumbers
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int index = 0; index < numbers.Count - 1; index++)
            {
                if (numbers[index] == numbers[index + 1])
                {
                    numbers[index] += numbers[index + 1];
                    numbers.RemoveAt(index + 1);
                    index = -1;
                }
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
