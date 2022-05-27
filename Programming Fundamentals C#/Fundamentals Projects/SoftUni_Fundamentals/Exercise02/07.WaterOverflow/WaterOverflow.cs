using System;

namespace _07.WaterOverflow
{
    class WaterOverflow
    {
        static void Main(string[] args)
        {
            const int CAPACITY = 255;
            int fillsNum = int.Parse(Console.ReadLine());
            int capacity = 0;

            for (int fill = 1; fill <= fillsNum; fill++)
            {
                int litersFilled = int.Parse(Console.ReadLine());

                if (capacity + litersFilled > CAPACITY)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                capacity += litersFilled;
            }
            Console.WriteLine(capacity);
        }
    }
}
