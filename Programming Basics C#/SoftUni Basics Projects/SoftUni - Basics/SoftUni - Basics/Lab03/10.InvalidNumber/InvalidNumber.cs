using System;

namespace _10.InvalidNumber
{
    class InvalidNumber
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isValid = number == 0 || number >= 100 && number <= 200;

            switch (isValid)
            {
                case true:
                    break;
                default:
                    Console.WriteLine("invalid");
                    break;
            }
        }
    }
}
