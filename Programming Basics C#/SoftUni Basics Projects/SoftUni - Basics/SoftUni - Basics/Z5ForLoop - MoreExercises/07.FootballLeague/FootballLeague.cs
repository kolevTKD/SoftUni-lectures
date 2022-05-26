using System;

namespace _07.FootballLeague
{
    class FootballLeague
    {
        static void Main(string[] args)
        {
            int stadiumCapacity = int.Parse(Console.ReadLine());
            int allFansNum = int.Parse(Console.ReadLine());
            double sectorACounter = 0;
            double sectorBCounter = 0;
            double sectorVCounter = 0;
            double sectorGCounter = 0;
            char secA = 'A';
            char secB = 'B';
            char secV = 'V';
            char secG = 'G';

            for (int i = 1; i <= allFansNum; i++)
            {
                char sector = char.Parse(Console.ReadLine());

                if (sector == secA)
                {
                    sectorACounter++;
                }

                else if (sector == secB)
                {
                    sectorBCounter++;
                }

                else if (sector == secV)
                {
                    sectorVCounter++;
                }

                else if (sector == secG)
                {
                    sectorGCounter++;
                }
            }

            double secAP = sectorACounter / allFansNum * 100;
            double secBP = sectorBCounter / allFansNum * 100;
            double secVP = sectorVCounter / allFansNum * 100;
            double secGP = sectorGCounter / allFansNum * 100;
            double totalFansP = (double)allFansNum / stadiumCapacity * 100;

            Console.WriteLine($"{secAP:f2}%");
            Console.WriteLine($"{secBP:f2}%");
            Console.WriteLine($"{secVP:f2}%");
            Console.WriteLine($"{secGP:f2}%");
            Console.WriteLine($"{totalFansP:f2}%");
        }
    }
}
