using System;

namespace _08.MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double baseNum = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            double result = MathPow(baseNum, power);
            Console.WriteLine(result);
        }

        static double MathPow(double baseNum, int power)
        {
            double result = 1;
            for (int i = 1; i <= power; i++)
            {
                result *= baseNum;
            }

            return result;
        }
    }
}
