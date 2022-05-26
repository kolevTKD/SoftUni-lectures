using System;

namespace _03.HappyNumbers
{
    class HappyNumbers
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int num1 = 1; num1 <= 9; num1++)
            {
                for (int num2 = 1; num2 <= 9; num2++)
                {
                    int sumNum1Num2 = num1 + num2;
                    bool isHappyFirst2 = false;

                    if (number % sumNum1Num2 == 0)
                    {
                        isHappyFirst2 = true;
                    }

                    for (int num3 = 1; num3 <= 9; num3++)
                    {
                        for (int num4 = 1; num4 <= 9; num4++)
                        {
                            int sumNum3Num4 = num3 + num4;
                            bool isHappySecond2 = false;

                            if (number % sumNum3Num4 == 0)
                            {
                                isHappySecond2 = true;
                            }

                            string numberStr = $"{num1}{num2}{num3}{num4} ";

                            if (isHappyFirst2 && isHappySecond2 && sumNum1Num2 == sumNum3Num4)
                            {
                                Console.Write(numberStr);
                            }
                        }
                    }
                }
            }
        }
    }
}
