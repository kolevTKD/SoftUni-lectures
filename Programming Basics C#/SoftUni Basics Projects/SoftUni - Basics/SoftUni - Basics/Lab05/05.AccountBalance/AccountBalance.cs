using System;

namespace _05.AccountBalance
{
    class AccountBalance
    {
        static void Main(string[] args)
        {
            double balance = 0;
            bool isValid = balance >= 0;
            string stop = "NoMoreMoney";

            while (isValid)
            {
                string input = Console.ReadLine();

                if (input == stop)
                {
                    break;
                }

                double increase = double.Parse(input);

                if (increase < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                balance += increase;
                Console.WriteLine($"Increase: {increase:f2}");
            }

            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
