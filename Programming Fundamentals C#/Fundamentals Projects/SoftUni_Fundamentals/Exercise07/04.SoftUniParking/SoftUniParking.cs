using System;
using System.Collections.Generic;

namespace _04.SoftUniParking
{
    class SoftUniParking
    {
        static void Main(string[] args)
        {
            int actionsCount = int.Parse(Console.ReadLine());
            Dictionary<string, string> users = new Dictionary<string, string>();
            string licensePlate = string.Empty;

            for (int action = 1; action <= actionsCount; action++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                string user = commands[1];

                if (command == "register")
                {
                    licensePlate = commands[2];

                    if (users.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");

                        continue;
                    }

                    users.Add(user, licensePlate);
                    Console.WriteLine($"{user} registered {licensePlate} successfully");
                }

                else if (command == "unregister")
                {
                    if (!users.ContainsKey(user))
                    {
                        Console.WriteLine($"ERROR: user {user} not found");

                        continue;
                    }

                    users.Remove(user);
                    Console.WriteLine($"{user} unregistered successfully");
                }
            }

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
