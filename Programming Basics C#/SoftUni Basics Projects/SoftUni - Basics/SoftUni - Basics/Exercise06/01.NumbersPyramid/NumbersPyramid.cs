using System;

namespace _01.NumbersPyramid
{
    class NumbersPyramid
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            int num = 1;
            bool isBigger = false;

            for (int rows = 1; rows <= inputNum; rows++)
            {
                for (int cols = 1; cols <= rows; cols++)
                {
                    if (num > inputNum)
                    {
                        isBigger = true;
                        break;
                    }
                    Console.Write($"{num} ");
                    num++;
                }
                if (isBigger)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
