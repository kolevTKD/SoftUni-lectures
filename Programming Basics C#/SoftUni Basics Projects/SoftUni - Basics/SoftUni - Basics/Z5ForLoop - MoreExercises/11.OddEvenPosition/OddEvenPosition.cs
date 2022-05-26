using System;

namespace _11.OddEvenPosition
{
    class OddEvenPosition
    {
        static void Main(string[] args)
        {
            int nums = int.Parse(Console.ReadLine());
            double oddSum = 0;
            double evenSum = 0;
            double maxValue = int.MinValue;
            double minValue = int.MaxValue;
            double oddMin = minValue;
            double oddMax = maxValue;
            double evenMin = minValue;
            double evenMax = maxValue;

            for (int i = 1; i <= nums; i++)
            {
                double newNum = double.Parse(Console.ReadLine());

                if (i % 2 == 1)
                {
                    oddSum += newNum;
                    if (newNum < oddMin)
                    {
                        oddMin = newNum;
                    }

                    if (newNum > oddMax)
                    {
                        oddMax = newNum;
                    }
                }

                else if (i % 2 == 0)
                {
                    evenSum += newNum;
                    if (newNum < evenMin)
                    {
                        evenMin = newNum;
                    }

                    if (newNum > evenMax)
                    {
                        evenMax = newNum;
                    }
                }
            }

            Console.WriteLine($"OddSum={oddSum:f2},");

            if (oddMin == int.MaxValue)
            {
                Console.WriteLine("OddMin=No,");
            }

            else
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }

            if (oddMax == int.MinValue)
            {
                Console.WriteLine("OddMax=No,");
            }

            else
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }

            Console.WriteLine($"EvenSum={evenSum:f2},");

            if (evenMin == int.MaxValue)
            {
                Console.WriteLine("EvenMin=No,");
            }

            else
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }

            if (evenMax == int.MinValue)
            {
                Console.WriteLine("EvenMax=No");
            }

            else
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
        }
    }
}
