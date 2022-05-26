using System;

namespace _08.PetShop
{
    class PetShop
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());
            double total = (dogFood * 2.50) + (catFood * 4.00);
            Console.WriteLine($"{total} lv.");
        }
    }
}
