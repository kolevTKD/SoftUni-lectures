using System;

namespace _12.TheSongOfTheWheels
{
    class TheSongOfTheWheels
    {
        static void Main(string[] args)
        {
            int control = int.Parse(Console.ReadLine());
            int passCounter = 0;
            string password = null;
            bool passNotFound = true;

            if (control < 4 || control > 144)
            {
                return;
            }

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    bool isValidFirst2 = false;

                    if (a < b)
                    {
                        isValidFirst2 = true;
                    }

                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            bool isValidSecond2 = false;

                            if (c > d)
                            {
                                isValidSecond2 = true;
                            }

                            if (isValidFirst2 && isValidSecond2)
                            {
                                if (a * b + c * d == control)
                                {
                                    passCounter++;
                                    Console.Write($"{a}{b}{c}{d} ");

                                    if (passCounter == 4)
                                    {
                                        password = $"{a}{b}{c}{d}";
                                        passNotFound = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (!passNotFound)
            {
                Console.WriteLine();
                Console.WriteLine($"Password: {password}");
                return;
            }

            else if (passNotFound)
            {
                if (passCounter > 0)
                {
                    Console.WriteLine();
                }

                Console.WriteLine("No!");
            }
        }
    }
}
