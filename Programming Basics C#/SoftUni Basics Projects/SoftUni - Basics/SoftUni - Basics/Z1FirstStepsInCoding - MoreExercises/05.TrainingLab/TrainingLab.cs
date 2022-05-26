using System;

namespace _05.TrainingLab
{
    class TrainingLab
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            int toCm = 100;
            double lengthInCm = length * toCm;
            double widthInCm = width * toCm;
            double widthNoWalkway = widthInCm - 100;

            int workspacesPerRow = (int)widthNoWalkway / 70;
            int workspacesPerCol = (int)lengthInCm / 120;
            int totalWorkspaces = workspacesPerRow * workspacesPerCol - 3;
            Console.WriteLine($"{totalWorkspaces}");
        }
    }
}
