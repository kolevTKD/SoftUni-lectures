using System;

namespace _11.MathOperations
{
    class MathOperations
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            double result = Calculation(num1, @operator, num2);
            Console.WriteLine(result);
        }

        static double Calculation(int num1, char @operator, int num2)
        {
            double result = 0;

            switch (@operator)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    result = num1 / num2;
                    break;
            }

            return result;
        }
    }
}
