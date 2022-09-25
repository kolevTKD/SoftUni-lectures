using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Wardrobe
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < count; i++)
            {
                string[] colorClothes = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colorColl = colorClothes[0];

                if (!wardrobe.ContainsKey(colorColl))
                {
                    wardrobe.Add(colorColl, new Dictionary<string, int>());
                }

                string[] clothesOfColor = colorClothes[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                foreach (string wearOfColor in clothesOfColor)
                {
                    if (!wardrobe[colorColl].ContainsKey(wearOfColor))
                    {
                        wardrobe[colorColl].Add(wearOfColor, 0);
                    }

                    wardrobe[colorColl][wearOfColor]++;
                }
            }

            string[] searched = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string color = searched[0];
            string clothing = searched[1];

            foreach (var kvp in wardrobe)
            {
                Console.WriteLine($"{kvp.Key} clothes:");

                foreach (var wear in kvp.Value)
                {
                    if (kvp.Key == color && wear.Key == clothing)
                    {
                        Console.WriteLine($"* {wear.Key} - {wear.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {wear.Key} - {wear.Value}");
                }
            }
        }
    }
}
