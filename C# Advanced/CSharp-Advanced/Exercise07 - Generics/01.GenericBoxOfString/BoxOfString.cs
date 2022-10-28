using System;

namespace _01.GenericBoxOfString
{
    public class BoxOfString
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int line = 0; line < lines; line++)
            {
                string input = Console.ReadLine();
                box.Items.Add(input);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
