using System;
using System.Linq;

namespace _04.ArrayRotation
{
    class ArrayRotation
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int rotation = 0; rotation < rotations; rotation++)
            {
                int tempNum = numbers[0];

                for (int index = 0; index < numbers.Length - 1; index++)
                {
                    numbers[index] = numbers[index + 1];
                }
                    numbers[numbers.Length - 1] = tempNum;
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
