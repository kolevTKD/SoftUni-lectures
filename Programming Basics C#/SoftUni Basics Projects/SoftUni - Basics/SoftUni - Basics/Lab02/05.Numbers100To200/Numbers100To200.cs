using System;

namespace _05.Numbers100To200
{
    class Numbers100To200
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            int hundred = 100;
            int twoHundred = 200;

            bool isLessThan100 = numberInput < hundred;
            bool isLessOrEqual200 = numberInput <= twoHundred;

            if (isLessThan100)
            {
                Console.WriteLine("Less than 100");
            }

            else if (isLessOrEqual200)
            {
                Console.WriteLine("Between 100 and 200");
            }

            else
            {
                Console.WriteLine("Greater than 200");
            }
        }
    }
}
