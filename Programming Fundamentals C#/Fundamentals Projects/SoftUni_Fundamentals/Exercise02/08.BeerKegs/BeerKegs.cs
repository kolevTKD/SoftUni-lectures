using System;

namespace _08.BeerKegs
{
    class BeerKegs
    {
        static void Main(string[] args)
        {
            int kegsNum = int.Parse(Console.ReadLine());
            double biggestKeg = int.MinValue;
            string currentModel = null;


            for (int currentKeg = 1; currentKeg <= kegsNum; currentKeg++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double kegVolume = Math.PI * Math.Pow(radius, 2) * height;

                if (kegVolume >= biggestKeg)
                {
                    biggestKeg = kegVolume;
                    currentModel = model;
                }
            }
            Console.WriteLine(currentModel);
        }
    }
}
