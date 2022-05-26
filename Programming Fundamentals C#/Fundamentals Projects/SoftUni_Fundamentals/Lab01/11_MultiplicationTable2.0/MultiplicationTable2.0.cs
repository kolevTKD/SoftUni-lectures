using System;

namespace _11_MultiplicationTable2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int result = num1 * num2;

            if(num2 > 10)
            {
                Console.WriteLine($"{num1} X {num2} = {result}");
            }

            else
            {
                for (int to10 = num2; to10 <= 10; to10++)
                {
                    result = num1 * to10;
                    Console.WriteLine($"{num1} X {to10} = {result}");
                }
            }
        }
    }
}
