using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class NetherRealms
    {
        static void Main(string[] args)
        {
            char[] separators = new char[] { ' ', ',' };
            string[] demonsNames = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string healthPattern = @"[^+\-*/.0-9,\s]";
            string damagePattern = @"(?<number>\-*\d+\.?\d*)";
            string operationPattern = @"(?<operation>[\*\/])";
            Regex healthRegex = new Regex(healthPattern);
            Regex damageRegex = new Regex(damagePattern);
            List<Demon> demons = new List<Demon>();

            for (int index = 0; index < demonsNames.Length; index++)
            {
                string currentName = demonsNames[index];
                MatchCollection healthMatches = healthRegex.Matches(currentName);
                MatchCollection damageMatches = damageRegex.Matches(currentName);
                string healthDigits = string.Join("", healthMatches).ToString();
                List<double> damageDigits = new List<double>();

                int healthPoints = 0;

                foreach (int hp in healthDigits)
                {
                    healthPoints += hp;
                }

                for (int i = 0; i < damageMatches.Count; i++)
                {
                    double currDigit = double.Parse(damageMatches[i].Groups["number"].Value);
                    damageDigits.Add(currDigit);
                }

                double damagePoints = damageDigits.Sum();

                MatchCollection operationMatches = Regex.Matches(currentName, operationPattern);

                foreach (Match match in operationMatches)
                {
                    if (match.Groups["operation"].Value == "*")
                    {
                        damagePoints *= 2;
                    }

                    else if (match.Groups["operation"].Value == "/" && damagePoints != 0)
                    {
                        damagePoints /= 2;
                    }
                }
                Demon demon = new Demon(currentName, healthPoints, damagePoints);
                demons.Add(demon);
            }

            List<Demon> sortedDemons = demons.OrderBy(x => x.DemonName).ToList();

            foreach (Demon demon in sortedDemons)
            {
                Console.WriteLine($"{demon.DemonName} - {demon.HealthPoints} health, {demon.DamagePoints:f2} damage");
            }
        }
    }

    class Demon
    {
        public Demon(string demonName, int healthPoints, double damagePoints)
        {
            DemonName = demonName;
            HealthPoints = healthPoints;
            DamagePoints = damagePoints;
        }

        public string DemonName { get; set; }
        public int HealthPoints { get; set; }
        public double DamagePoints { get; set; }
    }
}
