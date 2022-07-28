using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04.StarEnigma
{
    class StarEnigma
    {
        static void Main(string[] args)
        {
            int messagesToDecrypt = int.Parse(Console.ReadLine());
            string starPattern = @"[starSTAR]";
            Regex starRegex = new Regex(starPattern);
            string messagePattern = @"[^@\-!:>]*@(?<name>[A-Z][a-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<attackOrDestroy>[A|D])![^@\-!:>]*->(?<soldierCount>[\d]+)[^@\-!:>]*";
            Regex messageRegex = new Regex(messagePattern);
            List<Planet> attackedPlanets = new List<Planet>();
            List<Planet> destroyedPlanets = new List<Planet>();

            for (int currMessage = 1; currMessage <= messagesToDecrypt; currMessage++)
            {
                string message = Console.ReadLine();
                MatchCollection starMatches = starRegex.Matches(message);
                StringBuilder decrypted = new StringBuilder();

                for (int index = 0; index < message.Length; index++)
                {
                    char newChar = (char)(message[index] - starMatches.Count);
                    decrypted.Append(newChar);
                }

                Match match = Regex.Match(decrypted.ToString(), messagePattern);
                if (match.Success)
                {
                    string planetName = match.Groups["name"].Value;
                    string planetPopulation = match.Groups["population"].Value;
                    char attackOrDestroy = char.Parse(match.Groups["attackOrDestroy"].Value);
                    string soldierCount = match.Groups["soldierCount"].Value;
                    Planet planet = new Planet(planetName, planetPopulation, attackOrDestroy, soldierCount);

                    if (attackOrDestroy == 'A')
                    {
                        attackedPlanets.Add(planet);
                    }

                    else if (attackOrDestroy == 'D')
                    {
                        destroyedPlanets.Add(planet);
                    }
                }
            }

            List<Planet> sortedAttackedPlanets = attackedPlanets.OrderBy(x => x.PlanetName).ToList();
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var attackedPlanet in sortedAttackedPlanets)
            {
                Console.WriteLine($"-> {attackedPlanet.PlanetName}");
            }

            List<Planet> sortedDestroyedPlanets = destroyedPlanets.OrderBy(x => x.PlanetName).ToList();
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var destroyedPlanet in sortedDestroyedPlanets)
            {
                Console.WriteLine($"-> {destroyedPlanet.PlanetName}");
            }
        }
    }

    class Planet
    {
        public Planet(string planetName, string planetPopulation, char attackOrDestroy, string soldierCount)
        {
            PlanetName = planetName;
            PlanetPopulation = planetPopulation;
            AttackOrDestroy = attackOrDestroy;
            SoldierCount = soldierCount;
        }

        public string PlanetName { get; set; }
        public string PlanetPopulation { get; set; }
        public char AttackOrDestroy { get; set; }
        public string SoldierCount { get; set; }
    }
}
