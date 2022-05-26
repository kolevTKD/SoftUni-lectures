using System;

namespace _01.UniquePINCodes
{
    class UniquePINCodes
    {
        static void Main(string[] args)
        {
            int ceilingNum1 = int.Parse(Console.ReadLine());
            int ceilingNum2 = int.Parse(Console.ReadLine());
            int ceilingNum3 = int.Parse(Console.ReadLine());

            for (int num1 = 1; num1 <= ceilingNum1; num1++)
            {
                bool isEven1 = true;

                if (num1 % 2 != 0)
                {
                    isEven1 = false;
                    continue;
                }

                for (int num2 = 1; num2 <= ceilingNum2; num2++)
                {
                    bool isPrime = true;

                    if (num2 < 2 || num2 > 7)
                    {
                        isPrime = false;
                        continue;
                    }

                    for (int prime = 2; prime <= 7; prime++)
                    {
                        if (prime < num2)
                        {
                            if (num2 == 2)
                            {
                                isPrime = true;
                                break;
                            }

                            else if (num2 % prime == 0)
                            {
                                isPrime = false;
                                continue;
                            }
                        }
                    }

                    for (int num3 = 1; num3 <= ceilingNum3; num3++)
                    {
                        bool isEven3 = true;

                        if (num3 % 2 != 0)
                        {
                            isEven3 = false;
                            continue;
                        }

                        if (isEven1 && isPrime && isEven3)
                        {
                            Console.WriteLine($"{num1} {num2} {num3}");
                        }
                    }
                }
            }
        }
    }
}
