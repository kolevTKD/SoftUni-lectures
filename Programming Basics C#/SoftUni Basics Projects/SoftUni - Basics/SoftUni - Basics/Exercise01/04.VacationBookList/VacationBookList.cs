using System;

namespace _04.VacationBookList
{
    class VacationBookList
    {
        static void Main(string[] args)
        {
            int pagesToRead = int.Parse(Console.ReadLine());
            int pagesPerHour = int.Parse(Console.ReadLine());
            int daysToComplete = int.Parse(Console.ReadLine());

            int timeToRead = pagesToRead / pagesPerHour;
            int hoursPerDay = timeToRead / daysToComplete;

            Console.WriteLine(hoursPerDay);
        }
    }
}
