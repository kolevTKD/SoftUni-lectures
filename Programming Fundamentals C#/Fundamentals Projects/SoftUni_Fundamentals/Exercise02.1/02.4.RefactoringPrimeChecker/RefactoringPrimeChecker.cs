using System;

namespace _02._4.RefactoringPrimeChecker
{
    class RefactoringPrimeChecker
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            for (int currentNum = 2; currentNum <= num; currentNum++)
            {
                bool isPrime = true;
                for (int divider = 2; divider < currentNum; divider++)
                {
                    if (currentNum % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{currentNum} -> {isPrime.ToString().ToLower()}");
            }
        }
    }
}
