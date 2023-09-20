namespace EnterNumbers
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> validNumbers = new List<int>();

            int start = 1;
            int end = 100;

            while (validNumbers.Count != 10)
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
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                throw new FormatException();
            }
            else if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException();
            }

            return number;
        }
    }
}
