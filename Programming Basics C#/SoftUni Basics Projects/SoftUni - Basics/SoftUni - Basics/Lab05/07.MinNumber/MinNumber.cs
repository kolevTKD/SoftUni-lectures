using System;

namespace _07.MinNumber
{
    class MinNumber
    {
        static void Main(string[] args)
        {
            string input = null;
            string stop = "Stop";
            int min = int.MaxValue;

            while ((input = Console.ReadLine()) != stop)
            {
                int num = int.Parse(input);

                if (num < min)
                {
                    min = num;
                }
            }
            Console.WriteLine(min);
        }
    }
}
