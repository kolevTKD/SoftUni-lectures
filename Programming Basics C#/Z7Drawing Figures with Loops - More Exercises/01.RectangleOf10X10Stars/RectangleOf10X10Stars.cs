using System;

namespace _01.RectangleOf10X10Stars
{
    class RectangleOf10X10Stars
    {
        static void Main(string[] args)
        {
            int side = 10;

            for (int i = 1; i <= side; i++)
            {
                Console.WriteLine(new string('*', side));
            }
        }
    }
}
