using System;

namespace _02.CommonElements
{
    class CommonElements
    {
        static void Main(string[] args)
        {
            string[] array1 = Console.ReadLine().Split(" ");
            string[] array2 = Console.ReadLine().Split(" ");

            for (int index = 0; index < array1.Length; index++)
            {
                for (int index2 = 0; index2 < array2.Length; index2++)
                {
                    if (array1[index] == array2[index2])
                    {
                        Console.Write($"{array1[index]} ");
                    }
                }
            }
        }
    }
}
