using System;

namespace _05.GenericCountMethodStrings
{
    public class CountMethodStrings
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                box.Items.Add(input);
            }

            string elementToCompare = Console.ReadLine();
            Console.WriteLine(box.GetCount(elementToCompare));
        }
    }
}
