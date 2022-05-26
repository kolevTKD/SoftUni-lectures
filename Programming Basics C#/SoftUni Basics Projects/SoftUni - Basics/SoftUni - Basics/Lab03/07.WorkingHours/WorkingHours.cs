using System;

namespace _07.WorkingHours
{
    class WorkingHours
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            string dayOfWeek = Console.ReadLine();
            bool workingHours = hour >= 10 && hour <= 18;

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":

                    switch (workingHours)
                    {
                        case true:
                            Console.WriteLine("open");
                            break;
                        default:
                            Console.WriteLine("closed");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("closed");
                    break;
            }
        }
    }
}
