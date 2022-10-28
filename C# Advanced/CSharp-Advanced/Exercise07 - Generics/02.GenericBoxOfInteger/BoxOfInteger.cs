using System;

namespace _02.GenericBoxOfInteger
{
    public class BoxOfInteger
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();

            for (int line = 0; line < lines; line++)
            {
                int number = int.Parse(Console.ReadLine());
                box.Items.Add(number);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
