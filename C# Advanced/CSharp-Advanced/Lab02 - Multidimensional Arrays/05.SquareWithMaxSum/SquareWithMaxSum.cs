using System;

namespace _05.SquareWithMaxSum
{
    internal class SquareWithMaxSum
    {
        static void Main(string[] args)
        {
            int side = 2;
            string[] rowsAndCols = Console.ReadLine().Split(", ");
            int rows = int.Parse(rowsAndCols[0]);
            int cols = int.Parse(rowsAndCols[1]);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] nums = Console.ReadLine().Split(", ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(nums[col]);
                }
            }

            int maxSum = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int sum = 0;
                    sum += matrix[row, col];
                    sum += matrix[row, col + 1];
                    sum += matrix[row + 1, col];
                    sum += matrix[row + 1, col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            for (int row = startRow; row < startRow + side; row++)
            {
                for (int col = startCol; col < startCol + side; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
            //Console.WriteLine($"{matrix[startRow, startCol]} {matrix[startRow, startCol + 1]}");
            //Console.WriteLine($"{matrix[startRow + 1, startCol]} {matrix[startRow + 1, startCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
