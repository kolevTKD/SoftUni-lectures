using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    internal class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> printMin = (numbers) =>
            {
                int minNum = int.MaxValue;

                foreach (int num in numbers)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }

                return minNum;
            };

            Console.WriteLine(
                printMin(
                    Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray()));
        }
    }
}
