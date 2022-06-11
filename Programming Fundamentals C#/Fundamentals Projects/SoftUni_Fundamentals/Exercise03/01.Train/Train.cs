using System;

namespace _01.Train
{
    class Train
    {
        static void Main(string[] args)
        {
            int wagonsNum = int.Parse(Console.ReadLine());
            int[] wagons = new int[wagonsNum];
            int sum = 0;

            for (int index = 0; index < wagonsNum; index++)
            {
                wagons[index] = int.Parse(Console.ReadLine());
                sum += wagons[index];
            }

            for (int i = 0; i < wagons.Length; i++)
            {
                Console.Write($"{wagons[i]} ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
