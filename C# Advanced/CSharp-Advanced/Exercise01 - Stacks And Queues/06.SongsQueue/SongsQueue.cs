using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
    internal class SongsQueue
    {
        static void Main(string[] args)
        {
            string[] songsInQueue = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(songsInQueue);

            while (songs.Count > 0)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Play")
                {
                    songs.Dequeue();
                }

                else if (command == "Add")
                {
                    string song = String.Join(' ', commands.Skip(1));

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                        continue;
                    }

                    songs.Enqueue(song);
                }

                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
