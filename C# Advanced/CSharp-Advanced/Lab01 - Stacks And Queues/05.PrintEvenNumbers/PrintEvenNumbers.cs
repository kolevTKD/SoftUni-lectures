using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    internal class PrintEvenNumbers
    {
        static void Main(string[] args)
        {
            int[] numbersArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> numbers = new Queue<int>();

            for (int i = 0; i < numbersArr.Length; i++)
            {
                int currentNum = numbersArr[i];

                if (currentNum % 2 == 0)
                {
                    numbers.Enqueue(currentNum);
                }
            }

            Console.WriteLine($"{string.Join(", ", numbers)}");
        }
    }
}
