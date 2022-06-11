using System;

namespace _04.PrintingTriangle
{
    class PrintingTriangle
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            for (int firstHalf = 1; firstHalf <= input; firstHalf++)
            {
                PrintLine(1, firstHalf);
            }

            for (int secondHalf = input - 1; secondHalf >= 1; secondHalf--)
            {
                PrintLine(1, secondHalf);
            }
        }

        static void PrintLine(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
