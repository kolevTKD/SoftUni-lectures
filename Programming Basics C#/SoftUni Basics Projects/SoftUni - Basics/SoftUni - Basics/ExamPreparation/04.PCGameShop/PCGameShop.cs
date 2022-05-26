using System;

namespace _04.PCGameShop
{
    class PCGameShop
    {
        static void Main(string[] args)
        {
            int gamesSold = int.Parse(Console.ReadLine());
            int othersCounter = 0;
            int hearthstoneCounter = 0;
            int fortniteCounter = 0;
            int overwatchCounter = 0;

            string hearthstone = "Hearthstone";
            string fortnite = "Fornite";
            string overwatch = "Overwatch";

            for (int currentGame = 1; currentGame <= gamesSold; currentGame++)
            {
                string gameName = Console.ReadLine();

                if (gameName == hearthstone)
                {
                    hearthstoneCounter++;
                }

                else if (gameName == fortnite)
                {
                    fortniteCounter++;
                }

                else if (gameName == overwatch)
                {
                    overwatchCounter++;
                }

                else
                {
                    othersCounter++;
                }
            }

            double pHearthstoneSold = (double)hearthstoneCounter * 100 / gamesSold;
            double pFortniteSold = (double)fortniteCounter * 100 / gamesSold;
            double pOverwatchSold = (double)overwatchCounter * 100 / gamesSold;
            double pOthersSold = (double)othersCounter * 100 / gamesSold;

            Console.WriteLine($"Hearthstone - {pHearthstoneSold:f2}%");
            Console.WriteLine($"Fornite - {pFortniteSold:f2}%");
            Console.WriteLine($"Overwatch - {pOverwatchSold:f2}%");
            Console.WriteLine($"Others - {pOthersSold:f2}%");
        }
    }
}
