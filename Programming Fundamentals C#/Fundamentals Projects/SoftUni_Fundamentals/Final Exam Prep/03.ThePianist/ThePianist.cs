using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ThePianist
{
    class ThePianist
    {
        static void Main(string[] args)
        {
            int piecesCount = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, string>> listOfSongs = new Dictionary<string, Dictionary<string, string>>();

            for (int i = 1; i <= piecesCount; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|');
                string pieceName = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];
                listOfSongs.Add(pieceName, new Dictionary<string, string>());
                listOfSongs[pieceName].Add(composer, key);
            }

            string end = "Stop";
            string[] commands = Console.ReadLine().Split('|');
            string command = commands[0];

            while (command != end)
            {
                if (command == "Add")
                {
                    string pieceName = commands[1];
                    string composer = commands[2];
                    string key = commands[3];

                    Add(pieceName, composer, key, listOfSongs);
                }

                else if (command == "Remove")
                {
                    string pieceName = commands[1];

                    Remove(pieceName, listOfSongs);
                }

                else if (command == "ChangeKey")
                {
                    string pieceName = commands[1];
                    string newKey = commands[2];

                    ChangeKey(pieceName, newKey, listOfSongs);
                }

                commands = Console.ReadLine().Split('|');
                command = commands[0];
            }

            foreach (var song in listOfSongs)
            {
                string composer = song.Value.FirstOrDefault().Key;
                string key = song.Value.FirstOrDefault().Value;
                Console.WriteLine($"{song.Key} -> Composer: {composer}, Key: {key}");
            }
        }

        static Dictionary<string, Dictionary<string, string>> Add(string pieceName, string composer, string key, Dictionary<string, Dictionary<string, string>> listOfSongs)
        {
            if (listOfSongs.ContainsKey(pieceName))
            {
                Console.WriteLine($"{pieceName} is already in the collection!");
            }

            else
            {
                listOfSongs.Add(pieceName, new Dictionary<string, string>());
                listOfSongs[pieceName].Add(composer, key);
                Console.WriteLine($"{pieceName} by {composer} in {key} added to the collection!");
            }

            return listOfSongs;
        }

        static Dictionary<string, Dictionary<string, string>> Remove(string pieceName, Dictionary<string, Dictionary<string, string>> listOfSongs)
        {
            if (listOfSongs.ContainsKey(pieceName))
            {
                listOfSongs.Remove(pieceName);
                Console.WriteLine($"Successfully removed {pieceName}!");
            }

            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }

            return listOfSongs;
        }

        static Dictionary<string, Dictionary<string, string>> ChangeKey(string pieceName, string newKey, Dictionary<string, Dictionary<string, string>> listOfSongs)
        {
            if (listOfSongs.ContainsKey(pieceName))
            {
                string composerOfPiece = listOfSongs[pieceName].Keys.First();
                listOfSongs[pieceName][composerOfPiece] = newKey;
                Console.WriteLine($"Changed the key of {pieceName} to {newKey}!");
            }

            else
            {
                Console.WriteLine($"Invalid operation! {pieceName} does not exist in the collection.");
            }

            return listOfSongs;
        }
    }
}
