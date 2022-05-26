using System;

namespace _06.WeddingSeats
{
    class WeddingSeats
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int currentSectorRows = int.Parse(Console.ReadLine());
            int oddRowSeatsNum = int.Parse(Console.ReadLine());
            int seatsCounter = 0;
            int evenRowSeatsNum = 0;
            int totalSeastOccupied = 0;


            for (char currentSector = 'A'; currentSector <= lastSector; currentSector++)
            {
                for (int currentRow = 1; currentRow <= currentSectorRows; currentRow++)
                {
                    bool isOddRow = false;
                    bool isEvenRow = false;

                    if (currentRow % 2 == 0)
                    {
                        isEvenRow = true;
                        evenRowSeatsNum = oddRowSeatsNum + 2;
                    }
                    else
                    {
                        isOddRow = true;
                    }

                    for (char currentSeat = 'a'; currentSeat <= 'z'; currentSeat++)
                    {
                        seatsCounter++;

                        if (isOddRow)
                        {
                            if (seatsCounter <= oddRowSeatsNum)
                            {
                                Console.WriteLine($"{currentSector}{currentRow}{currentSeat}");
                                totalSeastOccupied++;

                            }
                        }

                        else if (isEvenRow)
                        {
                            if (seatsCounter <= evenRowSeatsNum)
                            {
                                Console.WriteLine($"{currentSector}{currentRow}{currentSeat}");
                                totalSeastOccupied++;
                            }
                        }

                        if (seatsCounter > oddRowSeatsNum && seatsCounter > evenRowSeatsNum)
                        {
                            seatsCounter = 0;
                            break;
                        }
                    }
                }
                currentSectorRows++;
            }
            Console.WriteLine(totalSeastOccupied);
        }
    }
}
