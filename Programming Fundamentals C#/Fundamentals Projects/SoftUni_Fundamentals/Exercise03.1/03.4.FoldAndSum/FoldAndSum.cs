using System;
using System.Linq;

namespace _03._4.FoldAndSum
{
    internal class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int k = nums.Length / 4;
            int[] topRow = new int[nums.Length / 2];
            int topFills = 0;

            for (int half1 = topRow.Length - k - 1; half1 >= 0; half1--)
            {
                topRow[topFills] = nums[half1];
                topFills++;
            }

            for (int half2 = nums.Length - 1; half2 >= nums.Length - k; half2--)
            {
                topRow[topFills] = nums[half2];
                topFills++;
            }

            int[] bottomRow = new int[nums.Length / 2];
            int bottomFills = 0;

            for (int midPart = k; midPart < nums.Length - k; midPart++)
            {
                bottomRow[bottomFills] = nums[midPart];
                bottomFills++;
            }

            for (int i = 0; i < topRow.Length; i++)
            {
                Console.Write($"{topRow[i] + bottomRow[i]} ");
            }
        }
    }
}
