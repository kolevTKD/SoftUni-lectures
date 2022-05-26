using System;

namespace _03.SumsPrimeNonPrime
{
    class SumsPrimeNonPrime
    {
        static void Main(string[] args)
        {
            string stop = "stop";
            string input = string.Empty;
            int primeSum = 0;
            int nonPrimeSum = 0;

            while (input != stop)
            {
                input = Console.ReadLine();
                if (input == stop)
                {
                    break;
                }
                int num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }

                bool isPrime = true;

                for (int prime = 2; prime < num; prime++)
                {
                    if (num % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primeSum += num;
                }
                else
                {
                    nonPrimeSum += num;
                }
            }
            Console.WriteLine($"Sum of all prime numbers is: {primeSum}");
            Console.WriteLine($"Sum of all non prime numbers is: {nonPrimeSum}");
        }
    }
}
