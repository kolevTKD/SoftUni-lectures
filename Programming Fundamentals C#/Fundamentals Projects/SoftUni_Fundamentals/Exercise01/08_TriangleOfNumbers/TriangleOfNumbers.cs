using System;

namespace _08_TriangleOfNumbers
{
    class TriangleOfNumbers
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int rows = 1;

            while (rows <= inputNum)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    Console.Write($"{rows} ");
                }

                Console.WriteLine();
                rows++;
            }
        }
    }
}
