using System;

namespace _05.AddAndSubtract
{
    class AddAndSubtract
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());

            int sum = Add(num1, num2);
            Console.WriteLine(Result(sum, num3));
        }

        static int Add(int num1, int num2)
        {
            int sum = num1 + num2;
            return sum;
        }

        static int Result(int num1, int num2)
        {
            int result = num1 - num2;
            return result;
        }
    }
}
