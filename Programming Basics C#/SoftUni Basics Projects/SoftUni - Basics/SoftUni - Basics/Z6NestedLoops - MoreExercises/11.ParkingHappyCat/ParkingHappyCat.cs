using System;

namespace _11.ParkingHappyCat
{
    class ParkingHappyCat
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());
            double parkingTax = 0;
            double totalForStay = 0;

            for (int currentDay = 1; currentDay <= days; currentDay++)
            {
                double totalPerDay = 0;

                for (int currentHour = 1; currentHour <= hoursPerDay; currentHour++)
                {
                    bool isValid = false;

                    if (currentDay % 2 == 0)
                    {
                        if (currentHour % 2 == 1)
                        {
                            parkingTax = 2.5;
                            isValid = true;
                        }
                    }

                    else if (currentDay % 2 == 1)
                    {
                        if (currentHour % 2 == 0)
                        {
                            parkingTax = 1.25;
                            isValid = true;
                        }
                    }

                    if (!isValid)
                    {
                        parkingTax = 1;
                    }

                    totalPerDay += parkingTax;
                }

                Console.WriteLine($"Day: {currentDay} - {totalPerDay:f2} leva");
                totalForStay += totalPerDay;
            }
            Console.WriteLine($"Total: {totalForStay:f2} leva");
        }
    }
}
