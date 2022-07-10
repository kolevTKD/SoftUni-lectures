using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    class Songs
    {
        static void Main(string[] args)
        {
            int songsNum = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int index = 1; index <= songsNum; index++)
            {
                string[] songData = Console.ReadLine().Split('_').ToArray();
                string type = songData[0];
                string name = songData[1];
                string time = songData[2];

                Song song = new Song();

                song.TypeList = type;
                song.Name = name;
                song.Time = time;

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
            }

            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        //public Song (string typeList, string name, string time)
        //{
        //    this.TypeList = typeList;
        //    this.Name = name;
        //    this.Time = time;
        //}
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }

    }
}
