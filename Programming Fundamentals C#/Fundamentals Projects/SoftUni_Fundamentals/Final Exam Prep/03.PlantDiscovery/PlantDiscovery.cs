using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PlantDiscovery
{
    class PlantDiscovery
    {
        static void Main(string[] args)
        {
            int plantsNum = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plantsInfo = new Dictionary<string, Plant>();

            for (int plantI = 1; plantI <= plantsNum; plantI++)
            {
                string[] kvpPlant = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string plantName = kvpPlant[0];
                int rarity = int.Parse(kvpPlant[1]);

                if (!plantsInfo.ContainsKey(plantName))
                {
                    Plant plant = new Plant(rarity, new List<double>());
                    plantsInfo.Add(plantName, plant);
                    continue;
                }

                plantsInfo[plantName].Rarity = rarity;
            }

            string end = "Exhibition";
            char[] separators = new char[] { ':', '-', ' ' };

            while (true)
            {
                string[] commands = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == end)
                {
                    break;
                }

                string plantName = commands[1];

                if (!plantsInfo.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (command)
                {
                    case "Rate":
                        double rating = double.Parse(commands[2]);
                        plantsInfo[plantName].Rating.Add(rating);

                        break;

                    case "Update":
                        int rarity = int.Parse(commands[2]);
                        plantsInfo[plantName].Rarity = rarity;

                        break;

                    case "Reset":
                        plantsInfo[plantName].Rating.Clear();
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plantsInfo)
            {
                if (plant.Value.Rating.Count == 0)
                {
                    plant.Value.Rating.Add(0);
                }

                double averageRating = plant.Value.Rating.Average();
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {averageRating:f2}");
            }
        }
    }

    class Plant
    {
        public Plant(int rarity, List<double> rating)
        {
            Rarity = rarity;
            Rating = rating;
        }
        public int Rarity { get; set; }
        public List<double> Rating { get; set; }
    }
}
