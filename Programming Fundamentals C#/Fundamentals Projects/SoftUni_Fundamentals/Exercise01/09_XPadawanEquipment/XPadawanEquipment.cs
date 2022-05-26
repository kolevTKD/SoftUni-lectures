using System;

namespace _09_XPadawanEquipment
{
    class XPadawanEquipment
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int studentsNum = students;
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
            double sabersCount = Math.Ceiling(students * 1.1);
            double totalForSabers = lightsaberPrice * sabersCount;
            double totalForRobes = robePrice * students;

            for (int i = 1; i <= students; i++)
            {
                if (i % 6 == 0)
                {
                    studentsNum--;
                }
            }

            double totalForBelts = beltPrice * studentsNum;
            double total = totalForSabers + totalForRobes + totalForBelts;
            double neededMoney = total - budget;

            Console.WriteLine(budget >= total ? $"The money is enough - it would cost {total:f2}lv." : $"John will need {neededMoney:f2}lv more.");
        }
    }
}
