using System;

namespace _07.RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int times = int.Parse(Console.ReadLine());
            string output = Repeated(input, times);
            Console.WriteLine(output);
        }

        static string Repeated(string input, int times)
        {
            string output = string.Empty;
            for (int i = 1; i <= times; i++)
            {
                output += input;

            }

            return output;
        }
    }
}
