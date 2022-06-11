using System;
using System.Linq;

namespace _03.ZigZagArrays
{
    class ZigZagArrays
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int[] evenArr = new int[number];
            int[] oddArr = new int[number];

            for (int i = 0; i < number; i++)
            {
                int[] currentNums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                if (i % 2 == 0)
                {
                    evenArr[i] = currentNums[0];
                    oddArr[i] = currentNums[1];
                }

                else if (i % 2 == 1)
                {
                    evenArr[i] = currentNums[1];
                    oddArr[i] = currentNums[0];
                }
            }

            Console.WriteLine(string.Join(" ",evenArr));
            Console.WriteLine(string.Join(" ", oddArr));
        }
    }
}
