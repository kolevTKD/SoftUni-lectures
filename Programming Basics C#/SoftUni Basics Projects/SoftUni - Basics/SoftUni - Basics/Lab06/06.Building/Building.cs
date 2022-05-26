using System;

namespace _06.Building
{
    class Building
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int rooms = int.Parse(Console.ReadLine());

            for (int fNum = floors; fNum >= 1; fNum--)
            {
                for (int rNum = 0; rNum < rooms; rNum++)
                {
                    if (fNum == floors)
                    {
                        Console.Write($"L{fNum}{rNum} ");
                    }
                    else if (fNum % 2 == 0)
                    {
                        Console.Write($"O{fNum}{rNum} ");
                    }
                    else
                    {
                        Console.Write($"A{fNum}{rNum} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
