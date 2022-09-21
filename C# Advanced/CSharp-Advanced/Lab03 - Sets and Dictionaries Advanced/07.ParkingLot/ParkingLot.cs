using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace _07.ParkingLot
{
    internal class ParkingLot
    {
        static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "END")
                {
                    break;
                }

                string direction = commands[0];
                string licensePlate = commands[1];

                switch (direction)
                {
                    case "IN":
                        if (!parkingLot.Contains(licensePlate))
                        {
                            parkingLot.Add(licensePlate);
                        }
                        break;

                    case "OUT":
                        if (parkingLot.Contains(licensePlate))
                        {
                            parkingLot.Remove(licensePlate);
                        }
                        break;
                }
            }

            Print(parkingLot);
        }

        static void Print(HashSet<string> parkingLot)
        {
            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var licensePlate in parkingLot)
            {
                Console.WriteLine(licensePlate);
            }
        }
    }
}
