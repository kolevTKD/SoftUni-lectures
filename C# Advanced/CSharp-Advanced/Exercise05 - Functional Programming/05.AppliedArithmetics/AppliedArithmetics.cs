using System;
using System.Linq;

namespace _05.AppliedArithmetics
{
    internal class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            string cmd = Console.ReadLine();
            Func<int, int> add = n => n + 1;
            Func<int, int> multiply = n => n * 2;
            Func<int, int> subtract = n => n - 1;
            Action<int[]> print = numbers => Console.WriteLine(string.Join(' ', numbers));

            while (cmd != "end")
            {
                switch (cmd)
                {
                    case "add":
                        numbers = numbers.Select(n => add(n)).ToArray();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => multiply(n)).ToArray();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => subtract(n)).ToArray();
                        break;
                    case "print":
                        print(numbers);
                        break;
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
