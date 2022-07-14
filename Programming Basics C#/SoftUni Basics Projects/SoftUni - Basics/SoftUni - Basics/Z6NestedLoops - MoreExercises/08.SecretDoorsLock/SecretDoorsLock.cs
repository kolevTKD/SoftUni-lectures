using System;

namespace _08.SecretDoorsLock
{
    class SecretDoorsLock
    {
        static void Main(string[] args)
        {
            int hunderdsCeiling = int.Parse(Console.ReadLine());
            int tensCeiling = int.Parse(Console.ReadLine());
            int onesCeiling = int.Parse(Console.ReadLine());

            for (int num1 = 1; num1 <= hunderdsCeiling; num1++)
            {
                bool isEven1 = true;

                if (num1 % 2 == 1)
                {
                    isEven1 = false;
                    continue;
                }

                for (int num2 = 1; num2 <= tensCeiling; num2++)
                {
                    bool isPrime = true;

                    if (num2 < 2 || num2 > 7)
                    {
                        isPrime = false;
                        continue;
                    }

                    for (int prime = 2; prime <= num2; prime++)
                    {
                        if (num2 == 2)
                        {
                            isPrime = true;
                        }
                        else if (num2 < 2)
                        {
                            isPrime = false;
                            continue;
                        }
                        else if (num2 % 2 == 0)
                        {
                            isPrime = false;
                        }
                    }

                    for (int num3 = 1; num3 <= onesCeiling; num3++)
                    {
                        bool isEven3 = true;

                        if (num3 % 2 == 1)
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
