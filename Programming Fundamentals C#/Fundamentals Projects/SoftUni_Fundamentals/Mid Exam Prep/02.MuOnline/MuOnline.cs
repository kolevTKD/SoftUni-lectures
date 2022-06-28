using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.MuOnline
{
    class MuOnline
    {
        static void Main(string[] args)
        {
            List<string> dungeonRooms = Console.ReadLine().Split('|').ToList();
            string command = "";
            int amount = 0;
            const int INITIALHEALTH = 100;
            int currentHealth = INITIALHEALTH;
            int initialBitcoins = 0;
            int roomNum = 0;

            for(int index = 0; index < dungeonRooms.Count; index++)
            {
                roomNum++;
                string[] currentRoom = dungeonRooms[index].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = currentRoom[0];
                amount = int.Parse(currentRoom[1]);
                
                if (command == "potion")
                {

                    if (currentHealth + amount > INITIALHEALTH)
                    {
                        amount = INITIALHEALTH - currentHealth;
                        Console.WriteLine($"You healed for {amount} hp.");
                        currentHealth = INITIALHEALTH;
                        Console.WriteLine($"Current health: {currentHealth} hp.");
                        continue;
                    }

                    currentHealth += amount;
                    Console.WriteLine($"You healed for {amount} hp.");
                    Console.WriteLine($"Current health: {currentHealth} hp.");

                }

                else if (command == "chest")
                {
                    initialBitcoins += amount;
                    Console.WriteLine($"You found {amount} bitcoins.");
                }

                else
                {
                    string monster = command;
                    currentHealth -= amount;

                    if (currentHealth > 0)
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }

                    else
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {roomNum}");
                        return;
                    }
                }
            }
            Console.WriteLine("You've made it!");
            Console.WriteLine($"Bitcoins: {initialBitcoins}");
            Console.WriteLine($"Health: {currentHealth}");
        }
    }
}
