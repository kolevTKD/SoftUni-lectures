using System;

namespace _03.Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    Add(num1, num2);
                    break;

                case "subtract":
                    Subtract(num1, num2);
                    break;

                case "multiply":
                    Multiply(num1, num2);
                    break;

                case "divide":
                    Divide(num1, num2);
                    break;
            }
        }

        static void Add(int a, int b)
        {
            int result = a + b;
            Console.WriteLine(result);
        }

        static void Subtract(int a, int b)
        {
            int result = a - b;
            Console.WriteLine(result);
        }

        static void Multiply(int a, int b)
        {
            int result = a * b;
            Console.WriteLine(result);
        }

        static void Divide(int a, int b)
        {
            int result = a / b;
            Console.WriteLine(result);
        }
    }
}
