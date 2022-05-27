using System;

namespace _04.SumOfChars
{
    class SumOfChars
    {
        static void Main(string[] args)
        {
            int charsNum = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= charsNum; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                sum += symbol;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
