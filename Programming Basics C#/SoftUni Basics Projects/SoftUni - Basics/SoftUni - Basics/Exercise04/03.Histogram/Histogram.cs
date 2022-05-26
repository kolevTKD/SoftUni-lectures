using System;

namespace _03.Histogram
{
    class Histogram
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int numCount1 = 0;
            int numCount2 = 0;
            int numCount3 = 0;
            int numCount4 = 0;
            int numCount5 = 0;

            for (int i = 0; i < n; i++)
            {
                int newNum = int.Parse(Console.ReadLine());

                if (newNum >= 1 && newNum <= 199)
                {
                    numCount1++;
                }
                else if (newNum >= 200 && newNum <= 399)
                {
                    numCount2++;
                }
                else if (newNum >= 400 && newNum <= 599)
                {
                    numCount3++;
                }
                else if (newNum >= 600 && newNum <= 799)
                {
                    numCount4++;
                }
                else if (newNum >= 800 && newNum <= 1000)
                {
                    numCount5++;
                }
            }

            double p1 = (double)numCount1 / n * 100;
            double p2 = (double)numCount2 / n * 100;
            double p3 = (double)numCount3 / n * 100;
            double p4 = (double)numCount4 / n * 100;
            double p5 = (double)numCount5 / n * 100;
            Console.WriteLine($"{p1:f2}%");
            Console.WriteLine($"{p2:f2}%");
            Console.WriteLine($"{p3:f2}%");
            Console.WriteLine($"{p4:f2}%");
            Console.WriteLine($"{p5:f2}%");
        }
    }
}
