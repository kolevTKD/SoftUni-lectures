using System;

namespace _06.MaxNumber
{
    class MaxNumber
    {
        static void Main(string[] args)
        {
            string input = null;
            string stop = "Stop";
            int max = int.MinValue;

            while ((input = Console.ReadLine()) != stop)
            {
                int num = int.Parse(input);

                if (num > max)
                {
                    max = num;
                }

            }
            Console.WriteLine(max);
        }
    }
}
