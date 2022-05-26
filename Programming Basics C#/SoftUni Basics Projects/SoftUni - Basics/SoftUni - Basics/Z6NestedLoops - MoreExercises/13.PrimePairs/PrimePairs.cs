using System;

namespace _13.PrimePairs
{
    class PrimePairs
    {
        static void Main(string[] args)
        {
            int beginningFirstPair = int.Parse(Console.ReadLine());
            int beginningSecondPair = int.Parse(Console.ReadLine());
            int endingDifferenceFirstPair = int.Parse(Console.ReadLine());
            int endingDifferenceSecondPair = int.Parse(Console.ReadLine());
            int endingFirstPair = beginningFirstPair + endingDifferenceFirstPair;
            int endingSecondPair = beginningSecondPair + endingDifferenceSecondPair;

            for (int num1 = beginningFirstPair; num1 <= endingFirstPair; num1++)
            {
                bool isPrimeFirst = true;

                if (num1 % 2 == 0)
                {
                    isPrimeFirst = false;
                    continue;
                }

                for (int primeCheck = 3; primeCheck <= 9; primeCheck++)
                {
                    if (num1 % primeCheck == 0)
                    {
                        isPrimeFirst = false;
                        break;
                    }
                }

                for (int num2 = beginningSecondPair; num2 <= endingSecondPair; num2++)
                {
                    bool isPrimeSecond = true;

                    if (num2 % 2 == 0)
                    {
                        isPrimeSecond = false;
                        continue;
                    }

                    for (int primeCheck = 3; primeCheck <= 9; primeCheck++)
                    {
                        if (num2 % primeCheck == 0)
                        {
                            isPrimeSecond = false;
                            break;
                        }
                    }

                    if (isPrimeFirst && isPrimeSecond)
                    {
                        Console.WriteLine($"{num1}{num2}");
                    }
                }
            }
        }
    }
}
