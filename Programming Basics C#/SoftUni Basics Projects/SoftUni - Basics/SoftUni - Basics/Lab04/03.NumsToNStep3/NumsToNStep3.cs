using System;

namespace _03.NumsToNStep3
{
    class NumsToNStep3
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            for (int b = 1; b <= a; b += 3)
            {
                Console.WriteLine(b);
            }
        }
    }
}
