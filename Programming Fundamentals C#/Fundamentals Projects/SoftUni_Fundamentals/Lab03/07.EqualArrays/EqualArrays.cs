using System;
using System.Linq;

namespace _07.EqualArrays
{
    class EqualArrays
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int[] array2 = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int sumOfArray = 0;

            for (int index = 0; index < array1.Length; index++)
            {
                if (array1[index] != array2[index])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
                    return;
                }
                sumOfArray += array1[index];
            }

            Console.WriteLine($"Arrays are identical. Sum: {sumOfArray}");
        }
    }
}
