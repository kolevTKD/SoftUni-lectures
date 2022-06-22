using System;

namespace _01.SoftUniReception
{
    class SoftUniReception
    {
        static void Main(string[] args)
        {
            int employee1 = int.Parse(Console.ReadLine());
            int employee2 = int.Parse(Console.ReadLine());
            int employee3 = int.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            int studentsPerHour = employee1 + employee2 + employee3;
            int hours = 0;

            while (students > 0)
            {
                hours++;

                if (hours % 4 == 0)
                {
                    continue;
                }

                students -= studentsPerHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
