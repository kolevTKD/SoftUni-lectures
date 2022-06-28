using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PhoneShop
{
    class PhoneShop
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = commands[0];
            string phone = "";
            string end = "End";

            while (command != end)
            {
                phone = commands[1];
                if (command == "Add")
                {
                    if (!phones.Contains(phone))
                    {
                        phones.Add(phone);
                    }
                }

                else if (command == "Remove")
                {
                    phones.Remove(phone);
                }

                else if (command == "Bonus phone")
                {
                    string[] oldNewPhone = commands[1].Split(':').ToArray();
                    string oldPhone = oldNewPhone[0];
                    string newPhone = oldNewPhone[1];

                    if (phones.Contains(oldPhone))
                    {
                        int oldIndex = 0;

                        for (int index = 0; index < phones.Count; index++)
                        {
                            if (phones[index] == oldNewPhone[0])
                            {
                                oldIndex = index;
                                break;
                            }
                        }

                        phones.Insert(oldIndex + 1, newPhone);
                    }
                }

                else if (command == "Last")
                {
                    if (phones.Contains(phone))
                    {
                        phones.Remove(phone);
                        phones.Add(phone);
                    }
                }
                commands = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                command = commands[0];
            }
            Console.WriteLine(string.Join(", ", phones));
        }
    }
}
