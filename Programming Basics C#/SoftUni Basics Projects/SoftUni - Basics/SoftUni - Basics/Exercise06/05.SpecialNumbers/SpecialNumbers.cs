using System;

namespace _05.SpecialNumbers
{
    class SpecialNumbers
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int floor = 1111; floor <= 9999; floor++)
            {
                bool isMagic = true;
                string currentNumStr = floor.ToString();

                for (int i = 0; i < currentNumStr.Length; i++)
                {
                    int currentNum = int.Parse(currentNumStr[i].ToString());
                    if (currentNum == 0)
                    {
                        isMagic = false;
                        break;
                    }
                    if (num % currentNum != 0)
                    {
                        isMagic = false;
                        break;
                    }
                }
                if (isMagic)
                {
                    Console.Write($"{floor} ");
                }
            }
        }
    }
}
