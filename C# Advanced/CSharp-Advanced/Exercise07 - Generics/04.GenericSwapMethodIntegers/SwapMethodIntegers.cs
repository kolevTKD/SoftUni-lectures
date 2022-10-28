using System;
using System.Linq;

namespace _04.GenericSwapMethodIntegers
{
    public class SwapMethodIntegers
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                box.Items.Add(number);
            }

            int[] indices = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            int index1 = indices[0];
            int index2 = indices[1];

            box.Swap(index1, index2);
            Console.WriteLine(box.ToString());
        }
    }
}
