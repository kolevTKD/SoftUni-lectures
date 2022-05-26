using System;

namespace _14.PasswordGenerator
{
    class PasswordGenerator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int counter1 = 0;
            int counter2 = 0;

            for (int symbol1 = 1; symbol1 <= n; symbol1++)
            {
                for (int symbol2 = 1; symbol2 <= n; symbol2++)
                {
                    for (char symbol3 = 'a'; symbol3 <= 'z'; symbol3++)
                    {
                        counter1++;

                        if (counter1 > l)
                        {
                            counter1 = 0;
                            break;
                        }

                        for (char symbol4 = 'a'; symbol4 <= 'z'; symbol4++)
                        {
                            counter2++;

                            if (counter2 > l)
                            {
                                counter2 = 0;
                                break;
                            }

                            for (int symbol5 = 1; symbol5 <= n; symbol5++)
                            {
                                if (symbol5 > symbol1 && symbol5 > symbol2)
                                {
                                    Console.Write($"{symbol1}{symbol2}{symbol3}{symbol4}{symbol5} ");
                                }

                                else
                                {
                                    continue;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
