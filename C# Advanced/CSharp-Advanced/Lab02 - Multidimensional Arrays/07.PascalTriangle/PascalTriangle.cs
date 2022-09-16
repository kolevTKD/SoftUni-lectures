using System;

namespace _07.PascalTriangle
{
    internal class PascalTriangle
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            long[][] pascal = new long[num][];

            for (int row = 0; row < pascal.Length; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col <= row; col++)
                {
                    if(row == 0)
                    {
                        pascal[row][col] = 1;
                        continue;
                    }

                    if (col == 0 || col == row)
                    {
                        pascal[row][col] = 1;
                        continue;
                    }

                    pascal[row][col] = pascal[row - 1][col] + pascal[row - 1][col - 1];
                }
            }

            for (int row= 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
