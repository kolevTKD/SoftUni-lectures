using System;
using System.Linq;

namespace _02.SumMatrixColumns
{
    internal class SumMatrixColumns
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = nums[col];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int colSum = 0;

                for (int row = 0; row < rows; row++)
                {
                    colSum += matrix[row, col];
                }

                Console.WriteLine(colSum);
            }


        }
    }
}
