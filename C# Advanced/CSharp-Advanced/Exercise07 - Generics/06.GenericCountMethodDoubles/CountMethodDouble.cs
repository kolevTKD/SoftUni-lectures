using System;

namespace _06.GenericCountMethodDoubles
{
    public class CountMethodDouble
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < count; i++)
            {
                double number = double.Parse(Console.ReadLine());
                box.Items.Add(number);
            }
            double numberToCompare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.GetCount(numberToCompare));
        }
    }
}
