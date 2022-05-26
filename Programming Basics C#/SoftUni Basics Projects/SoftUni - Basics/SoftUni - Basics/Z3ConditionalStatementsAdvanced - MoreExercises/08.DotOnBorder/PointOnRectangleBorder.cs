using System;

namespace _08.PointOnRectangleBorder
{
    class PointOnRectangleBorder
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            bool border = false;

            if (x == x1 || x == x2)
            {
                if (y >= y1 && y <= y2)
                {
                    border = true;
                }
            }

            if (y == y1 || y == y2)
            {
                if (x >= x1 && x <= x2)
                {
                    border = true;
                }
            }

            if (border)
            {
                Console.WriteLine("Border");
            }

            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}
