using System;

namespace _01.BonusScoringSystem
{
    class BonusScoringSystem
    {
        static void Main(string[] args)
        {
            int studentsNum = int.Parse(Console.ReadLine());
            int lectures = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());
            double maxAttendances = 0;
            double totalBonus = 0;
            double studentAttendances = 0;

            for (int student = 1; student <= studentsNum; student++)
            {
                studentAttendances = int.Parse(Console.ReadLine());

                if (studentAttendances > maxAttendances)
                {
                    maxAttendances = studentAttendances;
                    totalBonus = maxAttendances / lectures * (5 + bonus);
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(totalBonus)}.");
            Console.WriteLine($"The student has attended {Math.Ceiling(maxAttendances)} lectures.");
        }
    }
}
