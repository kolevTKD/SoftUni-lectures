using System;
using System.Collections.Generic;

namespace _03.HeroesOfCodeAndLogicVII
{
    class HeroesOfCodeAndLogicVII
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<int>> heroes = new Dictionary<string, List<int>>();

            for (int hero = 1; hero <= heroesCount; hero++)
            {
                string[] heroInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string heroName = heroInfo[0];
                int hp = int.Parse(heroInfo[1]);
                int mp = int.Parse(heroInfo[2]);

                heroes.Add(heroName, new List<int>() { hp, mp });
            }

            string[] commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
            string command = commands[0];
            string end = "End";

            while (command != end)
            {
                string heroName = commands[1];

                switch (command)
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(commands[2]);
                        string spellName = commands[3];
                        CastSpell(heroName, mpNeeded, spellName, heroes);

                        break;

                    case "TakeDamage":
                        int damageDone = int.Parse(commands[2]);
                        string attackerName = commands[3];
                        TakeDamage(heroName, damageDone, attackerName, heroes);

                        break;

                    case "Recharge":
                        int mpAmount = int.Parse(commands[2]);
                        Recharge(heroName, mpAmount, heroes);

                        break;

                    case "Heal":
                        int hpAmount = int.Parse(commands[2]);
                        Heal(heroName, hpAmount, heroes);

                        break;
                }

                commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                command = commands[0];
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($" HP: {hero.Value[0]}");
                Console.WriteLine($" MP: {hero.Value[1]}");
                    
            }
        }

        static void CastSpell(string heroName, int mpNeeded, string spellName, Dictionary<string, List<int>> heroes)
        {
            if (heroes[heroName][1] >= mpNeeded)
            {
                heroes[heroName][1] -= mpNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName][1]} MP!");
            }

            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }

            return;
        }

        static void TakeDamage(string heroName, int damageDone, string attackerName, Dictionary<string, List<int>> heroes)
        {
            if (heroes[heroName][0] - damageDone > 0)
            {
                heroes[heroName][0] -= damageDone;
                Console.WriteLine($"{heroName} was hit for {damageDone} HP by {attackerName} and now has {heroes[heroName][0]} HP left!");
            }

            else
            {
                heroes.Remove(heroName);
                Console.WriteLine($"{heroName} has been killed by {attackerName}!");
            }

            return;
        }

        static void Recharge(string heroName, int mpAmount, Dictionary<string, List<int>> heroes)
        {
            const int MAX_MP = 200;
            if (heroes[heroName][1] + mpAmount > MAX_MP)
            {
                mpAmount = MAX_MP - heroes[heroName][1];
                heroes[heroName][1] = MAX_MP;
            }

            else
            {
                heroes[heroName][1] += mpAmount;
            }
            Console.WriteLine($"{heroName} recharged for {mpAmount} MP!");

            return;
        }

        static void Heal(string heroName, int hpAmount, Dictionary<string, List<int>> heroes)
        {
            const int MAX_HP = 100;
            if (heroes[heroName][0] + hpAmount > MAX_HP)
            {
                hpAmount = MAX_HP - heroes[heroName][0];
                heroes[heroName][0] = MAX_HP;
            }

            else
            {
                heroes[heroName][0] += hpAmount;
            }
            Console.WriteLine($"{heroName} healed for {hpAmount} HP!");

            return;
        }
    }
}
