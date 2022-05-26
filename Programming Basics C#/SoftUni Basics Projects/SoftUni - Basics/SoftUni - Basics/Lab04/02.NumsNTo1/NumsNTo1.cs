using System;

namespace _02.NumsNTo1
{
    class NumsNTo1
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            for (int b = a; b >= 1; b--)
            {
                Console.WriteLine(b);
            }
        }
    }
}
