using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Numbers
{
    class Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            double average = numbers.Sum() / (double)numbers.Count;
            List<int> topNums = TopNums(numbers, average);

            if (topNums.Count == 0)
            {
                Console.WriteLine("No");

                return;
            }

            Console.WriteLine(string.Join(' ', topNums));
        }

        static List<int> TopNums(List<int> numbers, double average)
        {
            List<int> topNums = new List<int>();
            List<int> biggers = new List<int>();

            for (int index = 0; index < numbers.Count; index++)
            {
                if (numbers[index] > average)
                {
                    biggers.Add(numbers[index]);
                }
            }

            biggers.Sort();

            for (int index = biggers.Count - 1; index >= 0; index--)
            {
                topNums.Add(biggers[index]);

                if (topNums.Count == 5)
                {
                    break;
                }
            }

            return topNums;
        }
    }
}
