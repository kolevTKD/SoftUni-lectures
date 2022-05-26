using System;

namespace _10_MultiplicationTable
{
    class MultiplicationTable
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for(int times = 1; times <= 10; times++)
            {
                int result = number * times;
                Console.WriteLine($"{number} X {times} = {result}");
            }
        }
    }
}
