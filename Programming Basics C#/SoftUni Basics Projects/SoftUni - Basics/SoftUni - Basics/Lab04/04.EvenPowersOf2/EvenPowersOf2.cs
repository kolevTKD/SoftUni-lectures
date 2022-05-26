using System;

namespace _04.EvenPowersOf2
{
    class EvenPowersOf2
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int num = 2;

            for (int i = 0; i <= a; i += 2)
            {
                Console.WriteLine(Math.Pow(num, i));
            }
        }
    }
}
