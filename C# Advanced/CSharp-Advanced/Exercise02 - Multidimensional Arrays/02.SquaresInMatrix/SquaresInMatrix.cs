using System;
using System.Linq;

namespace _02.SquaresInMatrix
{
    internal class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];
            int equalSquarescount = 0;

            if (rows <= 2 && cols <= 2)
            {
                Console.WriteLine(0);

                return;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowValues = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (IsEqualSquare(matrix, ref row, ref col))
                    {
                        equalSquarescount++;
                    }
                }
            }

            Console.WriteLine(equalSquarescount);
        }

        static bool IsEqualSquare(string[,] matrix, ref int row, ref int col)
        {
            string symbol = matrix[row, col];
            return
                symbol == matrix[row, col + 1] &&
                symbol == matrix[row + 1, col] &&
                symbol == matrix[row + 1, col + 1];
        }
    }
}
