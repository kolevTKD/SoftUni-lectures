using System;

namespace _01.WorldTour
{
    class WorldTour
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(':');
            string command = commands[0];
            string end = "Travel";

            while (command != end)
            {
                if (command == "Switch")
                {
                    string oldString = commands[1];
                    string newString = commands[2];

                    if (stops.Contains(oldString))
                    {
                        stops = stops.Replace(oldString, newString);
                    }
                }

                else if (command == "Add Stop")
                {
                    int index = int.Parse(commands[1]);

                    if (index >= 0 && index < stops.Length)
                    {
                        stops = stops.Insert(index, commands[2]);
                    }
                }

                else if (command == "Remove Stop")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);

                    if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length)
                    {
                        stops = stops.Remove(startIndex, endIndex + 1 - startIndex);

                    }
                }

                Console.WriteLine(stops);
                commands = Console.ReadLine().Split(':');
                command = commands[0];
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
