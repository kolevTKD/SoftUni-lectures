using System;

namespace _10.MultiplyBy2
{
    class MultiplyBy2
    {
        static void Main(string[] args)
        {
            double num = 0;

            while (num >= 0)
            {
                num = double.Parse(Console.ReadLine());

                if (num < 0)
                {
                    Console.WriteLine("Negative number!");
                    break;
                }

                else
                {
                    num *= 2;
                    Console.WriteLine($"Result: {num:f2}");
                }
            }
        }
    }
}
