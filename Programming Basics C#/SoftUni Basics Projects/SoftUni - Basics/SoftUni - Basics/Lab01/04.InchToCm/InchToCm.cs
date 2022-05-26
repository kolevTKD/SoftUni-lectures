using System;

namespace _04.InchToCm
{
    class InchToCm
    {
        static void Main(string[] args)
        {
            double inch = double.Parse(Console.ReadLine());
            double inchToCm = inch * 2.54;
            Console.WriteLine(inchToCm);
        }
    }
}
