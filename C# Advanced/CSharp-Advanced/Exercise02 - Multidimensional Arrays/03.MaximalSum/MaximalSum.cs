using System;
using System.Linq;

namespace _03.MaximalSum
{
    internal class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];
            int maxSum = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int sum = GetSum(matrix, row, col);

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Print(matrix, maxSum, maxRow, maxCol);
        }

        static int GetSum(int[,] matrix, int row, int col)
        {
            return
                matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
        }

        static void Print(int[,] matrix, int maxSum, int maxRow, int maxCol)
        {
            Console.WriteLine($"Sum = {maxSum}");

            for (int row = maxRow; row <= maxRow + 2; row++)
            {
                for (int col = maxCol; col <= maxCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
