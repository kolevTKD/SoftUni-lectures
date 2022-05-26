using System;

namespace _06.OperationsBetweenNumbers
{
    class OperationsBetweenNumbers
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());

            double result = 0;

            bool even = result % 2 == 0;
            bool odd = result % 2 == 1;
            bool plusMinusTimes = operation == '+' || operation == '-' || operation == '*';
            string stringResult = null;
            string evenOrOdd = null;

            if (numTwo != 0)
            {
                switch (operation)
                {
                    case '+':
                        result = numOne + numTwo;
                        if (result % 2 == 0)
                        {
                            evenOrOdd = "even";
                        }
                        else
                        {
                            evenOrOdd = "odd";
                        }
                        break;
                    case '-':
                        result = numOne - numTwo;
                        if (result % 2 == 0)
                        {
                            evenOrOdd = "even";
                        }
                        else
                        {
                            evenOrOdd = "odd";
                        }
                        break;
                    case '*':
                        result = numOne * numTwo;
                        if (result % 2 == 0)
                        {
                            evenOrOdd = "even";
                        }
                        else
                        {
                            evenOrOdd = "odd";
                        }
                        break;
                    case '/':
                        result = numOne / (double)numTwo;
                        break;
                    case '%':
                        result = numOne % numTwo;
                        break;

                }
                if (operation == '/')
                {
                    stringResult = $"{numOne} {operation} {numTwo} = {result:f2}";
                    Console.WriteLine(stringResult);
                }
                else if (operation == '%')
                {
                    stringResult = $"{numOne} {operation} {numTwo} = {result}";
                    Console.WriteLine(stringResult);
                }
                else
                {
                    stringResult = $"{numOne} {operation} {numTwo} = {result} - {evenOrOdd}";
                    Console.WriteLine(stringResult);
                }

            }
            else
            {
                Console.WriteLine($"Cannot divide {numOne} by zero");
            }
        }
    }
}
