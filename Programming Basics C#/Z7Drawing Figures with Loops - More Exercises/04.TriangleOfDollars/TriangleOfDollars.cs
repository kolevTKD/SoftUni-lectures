using System;

namespace _04.TriangleOfDollars
{
    class TriangleOfDollars
    {
        static void Main(string[] args)
        {
            int inputNum = int. Parse(Console.ReadLine());

            for (int rows = 1; rows <= inputNum; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    Console.Write("$ ", cols);
                }
                Console.WriteLine();
            }
        }
    }
}
