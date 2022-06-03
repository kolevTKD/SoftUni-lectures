using System;

namespace _01.DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            int dayNum = int.Parse(Console.ReadLine());
            string[] dayOfWeek = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

            dayNum--;

            if (dayNum >= 0 && dayNum <= 6)
            {
                Console.WriteLine(dayOfWeek[dayNum]);
            }

            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
