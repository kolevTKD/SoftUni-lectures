using System;
using System.Linq;

namespace _06.EqualSums
{
    class EqualSums
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            for (int index = 0; index < numbers.Length; index++)
            {
                if (numbers.Length == 1)
                {
                    Console.WriteLine(index);
                    return;
                }

                int leftSum = 0;
                for (int left = index - 1; left >= 0; left--)
                {
                    leftSum += numbers[left];
                }

                int rightSum = 0;
                for (int right = index + 1; right < numbers.Length; right++)
                {
                    rightSum += numbers[right];
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(index);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
