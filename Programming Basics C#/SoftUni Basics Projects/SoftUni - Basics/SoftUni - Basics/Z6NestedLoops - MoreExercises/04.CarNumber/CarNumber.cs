using System;

namespace _04.CarNumber
{
    class CarNumber
    {
        static void Main(string[] args)
        {
            int intervalBegining = int.Parse(Console.ReadLine());
            int intervalEnding = int.Parse(Console.ReadLine());

            for (int num1 = intervalBegining; num1 <= intervalEnding; num1++)
            {
                bool firstIsEven = false;

                if (num1 % 2 == 0)
                {
                    firstIsEven = true;
                }

                for (int num2 = intervalBegining; num2 <= intervalEnding; num2++)
                {
                    for (int num3 = intervalBegining; num3 <= intervalEnding; num3++)
                    {
                        int sum = num2 + num3;
                        bool sumIsEven = false;

                        if (sum % 2 == 0)
                        {
                            sumIsEven = true;
                        }

                        for (int num4 = intervalBegining; num4 <= intervalEnding; num4++)
                        {
                            bool firstIsGreater = false;
                            bool lastIsEven = false;
                            bool isSpecialEven = false;

                            if (num4 % 2 == 0)
                            {
                                lastIsEven = true;
                            }

                            if (num1 > num4)
                            {
                                firstIsGreater = true;
                            }

                            if (firstIsEven && !lastIsEven)
                            {
                                isSpecialEven = firstIsEven && !lastIsEven;
                            }

                            else if (!firstIsEven && lastIsEven)
                            {
                                isSpecialEven = !firstIsEven && lastIsEven;
                            }

                            string numStr = $"{num1}{num2}{num3}{num4} ";

                            if (isSpecialEven && sumIsEven && firstIsGreater)
                            {
                                Console.Write(numStr);
                            }

                            else if (isSpecialEven && sumIsEven && firstIsGreater)
                            {
                                Console.Write(numStr);
                            }
                        }
                    }
                }
            }
        }
    }
}
