using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    class RemoveNegativesAndReverse
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            for (int index = 0; index < numbers.Count; index++)
            {
                if (numbers[index] < 0)
                {
                    numbers.RemoveAt(index);
                    index--;
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }

            numbers.Reverse();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
