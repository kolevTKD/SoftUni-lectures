using System;

namespace GiftsFromSanta
{
    class GiftsFromSanta
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());

            for(int num1 = m; num1 >= n; num1--)
            {
                if(num1 % 2 == 0 && num1 % 3 == 0)
                {
                    if(num1 == s)
                    {
                        return;
                    }
                    Console.Write($"{num1} ");
                }
            }
        }
    }
}
