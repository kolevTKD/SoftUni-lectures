using System;

namespace _07.NxNMatrix
{
    class NxNMatrix
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Matrix(input);
        }

        static void Matrix(int input)
        {
            for (int rows = 1; rows <= input; rows++)
            {
                for (int cols = 1; cols <= input; cols++)
                {
                    Console.Write($"{input} ");
                }
                Console.WriteLine();
            }
            return;
        }
    }
}
