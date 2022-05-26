using System;

namespace _01.RoomPainting
{
    class RoomPainting
    {
        static void Main(string[] args)
        {
            int paintsNum = int.Parse(Console.ReadLine());
            int wallapersNum = int.Parse(Console.ReadLine());
            double glovesPrice = double.Parse(Console.ReadLine());
            double brushPrice = double.Parse(Console.ReadLine());
            double paintPrice = 21.5;
            double wallpaperPrice = 5.2;
            double glovesNum = Math.Ceiling(wallapersNum * 0.35);
            double brushesNum = Math.Floor(paintsNum * 0.48);
            double totalForPaints = paintsNum * paintPrice;
            double totalForWallpapers = wallapersNum * wallpaperPrice;
            double totalForGloves = glovesNum * glovesPrice;
            double totalForBrushes = brushesNum * brushPrice;
            double totalForAll = totalForPaints + totalForWallpapers + totalForGloves + totalForBrushes;
            double delivery = totalForAll / 15;

            Console.WriteLine($"This delivery will cost {delivery:f2} lv.");
        }
    }
}
