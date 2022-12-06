namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;

    public class EnterNumbers
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;

            List<int> validNumbers = new List<int>();

            while (validNumbers.Count < 10)
            {
                try
                {
                    start = ReadNumber(start, end);
                    validNumbers.Add(start);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - 100!");
                }

            }

            Console.WriteLine(string.Join(", ", validNumbers));
        }

        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int result))
            {
                throw new FormatException();
            }

            if (result <= start || result >= end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return result;
        }
    }
}
