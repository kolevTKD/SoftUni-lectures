using System;
using System.Collections.Generic;

namespace _03.P_rates
{
    class Pirates
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> markedCities = new Dictionary<string, City>();
            string sail = "Sail";

            while (true)
            {
                string[] cities = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);

                if (cities[0] == sail)
                {
                    break;
                }

                string cityName = cities[0];
                int population = int.Parse(cities[1]);
                int gold = int.Parse(cities[2]);

                if (!markedCities.ContainsKey(cityName))
                {
                    City city = new City(population, gold);
                    markedCities.Add(cityName, city);
                }

                else
                {
                    markedCities[cityName].Population += population;
                    markedCities[cityName].Gold += gold;
                }
            }

            string end = "End";
            while (true)
            {
                string[] events = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

                if (events[0] == end)
                {
                    break;
                }
                string action = events[0];
                string town = events[1];

                switch (action)
                {
                    case "Plunder":
                        int peopleKilled = int.Parse(events[2]);
                        int goldStolen = int.Parse(events[3]);
                        markedCities[town].Population -= peopleKilled;
                        markedCities[town].Gold -= goldStolen;

                        Console.WriteLine($"{town} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

                        if (markedCities[town].Population <= 0 || markedCities[town].Gold <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            markedCities.Remove(town);
                        }

                        break;

                    case "Prosper":
                        int goldIncrease = int.Parse(events[2]);

                        if (goldIncrease < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }

                        else
                        {
                            markedCities[town].Gold += goldIncrease;
                            Console.WriteLine($"{goldIncrease} gold added to the city treasury. {town} now has {markedCities[town].Gold} gold.");
                        }

                        break;
                }
            }

            if (markedCities.Count == 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
                return;
            }

            Console.WriteLine($"Ahoy, Captain! There are {markedCities.Count} wealthy settlements to go to:");
            foreach (var markedCity in markedCities)
            {
                Console.WriteLine($"{markedCity.Key} -> Population: {markedCity.Value.Population} citizens, Gold: {markedCity.Value.Gold} kg");
            }
        }
    }

    class City
    {
        public City(int population, int gold)
        {
            Population = population;
            Gold = gold;
        }

        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
