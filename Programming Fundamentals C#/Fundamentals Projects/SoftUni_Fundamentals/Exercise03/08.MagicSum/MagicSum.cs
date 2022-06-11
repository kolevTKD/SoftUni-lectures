using System;
using System.Linq;

namespace _08.MagicSum
{
    class MagicSum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int magicNum = int.Parse(Console.ReadLine());

            for (int index = 0; index < numbers.Length; index++)
            {
                for (int checker = index + 1; checker < numbers.Length; checker++)
                {
                    if (numbers[index] + numbers[checker] == magicNum)
                    {
                        int magic1 = numbers[index];
                        int magic2 = numbers[checker];
                        Console.WriteLine(string.Join(" ", magic1, magic2));
                    }
                }
            }
        }
    }
}
