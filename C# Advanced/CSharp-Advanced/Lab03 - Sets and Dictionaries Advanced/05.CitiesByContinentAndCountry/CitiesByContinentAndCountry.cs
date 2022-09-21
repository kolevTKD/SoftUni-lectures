using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class CitiesByContinentAndCountry
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, List<string>>> continentCountries = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int current = 0; current < count; current++)
            {
                string[] continentInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string continent = continentInfo[0];
                string country = continentInfo[1];
                string city = continentInfo[2];

                if (continentCountries.ContainsKey(continent))
                {
                    if (!continentCountries[continent].ContainsKey(country))
                    {
                        continentCountries[continent].Add(country, new List<string>());
                        continentCountries[continent][country].Add(city);
                    }

                    else
                    {
                        continentCountries[continent][country].Add(city);
                    }
                }

                else
                {
                    continentCountries.Add(continent, new Dictionary<string, List<string>>());
                    continentCountries[continent].Add(country, new List<string>());
                    continentCountries[continent][country].Add(city);
                }
            }

            foreach (var continent in continentCountries)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"  {country.Key} -> {string.Join(", ", country.Value)}");
                    Console.WriteLine();
                }
            }
        }
    }
}
