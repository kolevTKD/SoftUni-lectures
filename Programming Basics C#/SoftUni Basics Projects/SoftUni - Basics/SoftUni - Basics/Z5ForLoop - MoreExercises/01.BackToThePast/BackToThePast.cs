using System;

namespace _01.BackToThePast
{
    class BackToThePast
    {
        static void Main(string[] args)
        {
            double moneyInherited = double.Parse(Console.ReadLine());
            int yearToLive = int.Parse(Console.ReadLine());
            int age = 18;
            double evenYearSpending = 0;
            double oddYearSpending = 0;
            double moneyLeft = 0;

            for (int year = 1800; year <= yearToLive; year++)
            {
                if (year % 2 == 0)
                {
                    evenYearSpending = 12000;
                    moneyLeft = moneyInherited -= evenYearSpending;
                }

                else if (year % 2 == 1)
                {
                    oddYearSpending = 12000 + (50 * age);
                    moneyLeft = moneyInherited -= oddYearSpending;
                }
                age++;
            }
            if (moneyLeft >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {moneyLeft:f2} dollars left.");
            }

            else
            {
                Console.WriteLine($"He will need {Math.Abs(moneyLeft):f2} dollars to survive.");
            }
        }
    }
}
