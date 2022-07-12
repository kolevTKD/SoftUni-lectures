using System;

namespace _05.SquareFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int insideFrame = inputNum - 2;

            for (int rows = 1; rows <= inputNum; rows++)
            {
                if (rows == 1 || rows == inputNum)
                {
                    Console.WriteLine("+ ");
                }
            }
        }
    }
}
