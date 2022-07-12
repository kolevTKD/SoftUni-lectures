using System;

namespace FootballSouvenirs
{
    class FootballSouvenirs
    {
        static void Main(string[] args)
        {
            string team = Console.ReadLine();
            string souvenirType = Console.ReadLine();
            int souvenirsNum = int.Parse(Console.ReadLine());
            string argentina = "Argentina";
            string brazil = "Brazil";
            string croatia = "Croatia";
            string denmark = "Denmark";
            string flags = "flags";
            string caps = "caps";
            string posters = "posters";
            string stickers = "stickers";
            double flagsPrice = 0;
            double capsPrice = 0;
            double postersPrice = 0;
            double stickersPrice = 0;
            double total = 0;

            if(team != argentina && team != brazil && team !=croatia && team != denmark)
            {
                Console.WriteLine("Invalid country!");
                return;
            }
            if(team == argentina)
            {
                flagsPrice = 3.25;
                capsPrice = 7.2;
                postersPrice = 5.1;
                stickersPrice = 1.25;
            }
            else if(team == brazil)
            {
                flagsPrice = 4.2;
                capsPrice = 8.5;
                postersPrice = 5.35;
                stickersPrice = 1.2;
            }
            else if(team == croatia)
            {
                flagsPrice = 2.75;
                capsPrice = 6.9;
                postersPrice = 4.95;
                stickersPrice = 1.1;
            }
            else if(team == denmark)
            {
                flagsPrice = 3.1;
                capsPrice = 6.5;
                postersPrice = 4.8;
                stickersPrice = 0.9;
            }

            if(souvenirType != flags && souvenirType != caps && souvenirType != posters && souvenirType != stickers)
            {
                Console.WriteLine("Invalid stock!");
                return;
            }
            if(souvenirType == flags)
            {
                total = souvenirsNum * flagsPrice;
            }
            else if(souvenirType == caps)
            {
                total = souvenirsNum * capsPrice;
            }
            else if(souvenirType == posters)
            {
                total = souvenirsNum * postersPrice;
            }
            else if(souvenirType == stickers)
            {
                total = souvenirsNum * stickersPrice;
            }
            Console.WriteLine($"Pepi bought {souvenirsNum} {souvenirType} of {team} for {total:f2} lv.");
        }
    }
}
