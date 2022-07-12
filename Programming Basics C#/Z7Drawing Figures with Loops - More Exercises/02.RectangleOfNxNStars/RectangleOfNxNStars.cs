using System;

namespace _02.RectangleOfNxNStars
{
    class RectangleOfNxNStars
    {
        static void Main(string[] args)
        {
            int side = int.Parse(Console.ReadLine());

            for (int i = 1; i <= side; i++)
            {
                Console.WriteLine(new string('*', side));
            }
        }
    }
}
