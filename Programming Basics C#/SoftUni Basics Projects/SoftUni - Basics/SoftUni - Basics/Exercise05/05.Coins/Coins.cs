using System;

namespace _05.Coins
{
    class Coins
    {
        static void Main(string[] args)
        {
            int coinCounter = 0;
            int twoLev = 200;
            int oneLev = 100;
            int fiftySt = 50;
            int twentySt = 20;
            int tenSt = 10;
            int fiveSt = 5;
            int twoSt = 2;
            int oneSt = 1;
            double sumInput = double.Parse(Console.ReadLine()) * 100;
            int change = (int)sumInput;

            while (change > 0)
            {
                if (change >= twoLev)
                {
                    change -= twoLev;
                }
                else if (change >= oneLev)
                {
                    change -= oneLev;
                }
                else if (change >= fiftySt)
                {
                    change -= fiftySt;
                }
                else if (change >= twentySt)
                {
                    change -= twentySt;
                }
                else if (change >= tenSt)
                {
                    change -= tenSt;
                }
                else if (change >= fiveSt)
                {
                    change -= fiveSt;
                }
                else if (change >= twoSt)
                {
                    change -= twoSt;
                }
                else if (change >= oneSt)
                {
                    change -= oneSt;
                }
                coinCounter++;
            }
            Console.WriteLine(coinCounter);
        }
    }
}
