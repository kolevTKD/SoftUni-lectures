using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodStrings
{
    public class SwapMethodStrings
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                string line = Console.ReadLine();
                box.Items.Add(line);
            }
            int[] indices = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToArray();
            int index1 = indices[0];
            int index2 = indices[1];

            box.Swap(index1, index2);
            Console.WriteLine(box.ToString());
        }
    }
}
