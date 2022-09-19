using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    internal class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int row = 0; row < matrix.Length; row++)
            {
                int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                matrix[row] = new int[nums.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = nums[col];
                }
            }

            int primarySum = 0;
            int secondarySum = 0;

            for (int primary = 0, secondary = matrix.Length - 1; primary < matrix.Length; primary++, secondary--)
            {
                primarySum += matrix[primary][primary];
                secondarySum += matrix[primary][secondary];
            }

            int diff = Math.Abs(primarySum - secondarySum);
            Console.WriteLine(diff);
        }
    }
}
