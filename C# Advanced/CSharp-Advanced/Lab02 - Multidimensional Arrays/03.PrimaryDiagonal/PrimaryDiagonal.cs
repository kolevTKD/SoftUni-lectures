using System;

namespace _03.PrimaryDiagonal
{
    internal class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[][] matrix = new int[size][];

            for (int row = 0; row < matrix.Length; row++)
            {
                string[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                matrix[row] = new int[nums.Length];

                for (int col = 0; col < size; col++)
                {
                    matrix[row][col] = int.Parse(nums[col]);
                }
            }

            int sum = 0;

            for (int index = 0; index < matrix.Length; index++)
            {
                sum += matrix[index][index];
            }

            Console.WriteLine(sum);
        }
    }
}
