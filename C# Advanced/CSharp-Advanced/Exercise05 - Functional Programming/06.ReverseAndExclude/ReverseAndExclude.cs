using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    internal class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            int divider = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = n => n % divider != 0;

            Func<int[], int[]> reverse = numbers =>
            {
                int[] reversed = new int[numbers.Length];

                for (int start = 0, end = numbers.Length - 1; start < reversed.Length; start++, end--)
                {
                    reversed[start] = numbers[end];
                }

                return reversed;
            };

            Func<int[], Predicate<int>, int[]> filter = (numbers, match) =>
            {
                int[] filteredNums = Array.FindAll(numbers, match);

                return filteredNums;
            };

            Action<int[]> print = numbers => Console.WriteLine(string.Join(' ', numbers));

            numbers = reverse(numbers);
            numbers = filter(numbers, isDivisible);
            print(numbers);

        }
    }
}
