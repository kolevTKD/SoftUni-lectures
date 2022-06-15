using System;

namespace _08.FactorialDivision
{
    class FactorialDivision
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double factorialNum1 = Factorial(num1);
            double factorialNum2 = Factorial(num2);
            Result(factorialNum1, factorialNum2);
        }

        static double Factorial(int number)
        {
            double factorial = 1;

            for (int i = number; i > 1; i--)
            {
                factorial *= i;
            }
            return factorial;
        }

        static void Result(double num1, double num2)
        {
            double result = num1 / num2;
            Console.WriteLine($"{result:f2}");
        }
    }
}
