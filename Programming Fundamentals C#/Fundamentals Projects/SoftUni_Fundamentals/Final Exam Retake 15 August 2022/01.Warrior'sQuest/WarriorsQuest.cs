using System;

namespace _01.Warrior_sQuest
{
    class WarriorsQuest
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string mainCommand = commands[0];

                if (mainCommand == "For" && commands[1] == "Azeroth")
                {
                    break;
                }

                else
                {
                    switch (mainCommand)
                    {
                        case "GladiatorStance":
                            skill = skill.ToUpper();
                            Console.WriteLine(skill);
                            break;

                        case "DefensiveStance":
                            skill = skill.ToLower();
                            Console.WriteLine(skill);
                            break;

                        case "Dispel":
                            int index = int.Parse(commands[1]);
                            char letter = char.Parse(commands[2]);

                            if (index >= 0 && index < skill.Length)
                            {
                                skill = skill.Remove(index, 1);
                                skill = skill.Insert(index, letter.ToString());
                                Console.WriteLine("Success!");
                            }

                            else
                            {
                                Console.WriteLine("Dispel too weak.");
                            }

                            break;

                        case "Target":

                            if (commands[1] == "Change")
                            {
                                string containing = commands[2];
                                string toReplace = commands[3];

                                if (skill.Contains(containing))
                                {
                                    skill = skill.Replace(containing, toReplace);
                                }
                                Console.WriteLine(skill);
                            }

                            else if (commands[1] == "Remove")
                            {
                                string substring = commands[2];

                                if (skill.Contains(substring))
                                {
                                    int indexOfString = skill.IndexOf(substring);
                                    skill = skill.Remove(indexOfString, substring.Length);
                                    Console.WriteLine(skill);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Command doesn't exist!");
                            }
                            break;

                        default:
                            Console.WriteLine("Command doesn't exist!");
                            break;
                    }
                }
            }
        }
    }
}
