using System;

namespace _09.Aquarium
{
    class Aquarium
    {
        static void Main(string[] args)
        {
            int lenghtInCm = int.Parse(Console.ReadLine());
            int widthInCm = int.Parse(Console.ReadLine());
            int heightInCm = int.Parse(Console.ReadLine());
            double percentUsed = double.Parse(Console.ReadLine());

            double decimeter = 10;
            int percentDivider = 100;
            double percentage = percentUsed / percentDivider;

            double lenghtInDm = lenghtInCm / decimeter;
            double widthInDm = widthInCm / decimeter;
            double heightInDm = heightInCm / decimeter;

            double acquariumCapacity = lenghtInDm * widthInDm * heightInDm;
            double accessories = acquariumCapacity * percentage;
            double total = acquariumCapacity - accessories;

            Console.WriteLine(total);
        }
    }
}
