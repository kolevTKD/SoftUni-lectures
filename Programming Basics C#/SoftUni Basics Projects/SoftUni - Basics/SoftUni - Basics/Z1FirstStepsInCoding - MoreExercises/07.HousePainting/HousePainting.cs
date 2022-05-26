using System;

namespace _07.HousePainting
{
    class HousePainting
    {
        static void Main(string[] args)
        {
            double houseHeight = double.Parse(Console.ReadLine());
            double houseLength = double.Parse(Console.ReadLine());
            double roofHeight = double.Parse(Console.ReadLine());
            double greenPerSqM = 3.4;
            double redPerSqM = 4.3;
            double door = 1.2 * 2;
            double window = 1.5 * 1.5; ;
            double frontBack = 2 * (houseHeight * houseHeight);
            double side = 2 * (houseHeight * houseLength);
            double areaFB = frontBack - door;
            double areaSide = side - 2 * window;
            double roofTriangle = (houseHeight * roofHeight) / 2;
            double totalRoofArea = side + 2 * roofTriangle;
            double totalBodyArea = areaFB + areaSide;
            double totalGreenPaint = totalBodyArea / greenPerSqM;
            double totalRedPaint = totalRoofArea / redPerSqM;

            Console.WriteLine($"{totalGreenPaint:f2}");
            Console.WriteLine($"{totalRedPaint:f2}");
        }
    }
}
