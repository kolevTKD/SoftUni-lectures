using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08.SoftUniParty
{
    internal class SoftUniParty
    {
        static void Main(string[] args)
        {
            string guest = Console.ReadLine();
            string regular = @"^([A-Za-z]{1}[A-Za-z\d]{7})$";
            string vip = @"^[\d]{1}[A-Za-z\d]{7}$";
            HashSet<string> regularGuests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();

            while (guest != "PARTY")
            {
                Match regularMatch = Regex.Match(guest, regular);
                Match vipMatch = Regex.Match(guest, vip);

                if (regularMatch.Success)
                {
                    regularGuests.Add(guest);
                }

                else if (vipMatch.Success)
                {
                    vipGuests.Add(guest);
                }

                guest = Console.ReadLine();
            }

            guest = Console.ReadLine();

            while (guest != "END")
            {
                regularGuests.Remove(guest);
                vipGuests.Remove(guest);

                guest = Console.ReadLine();
            }

            Print(regularGuests, vipGuests);
        }

        static void Print(HashSet<string> regularGuests, HashSet<string> vipGuests)
        {
            int leftGuests = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(leftGuests);

            foreach (string vipGuest in vipGuests)
            {
                Console.WriteLine(vipGuest);
            }

            foreach (string regularGuest in regularGuests)
            {
                Console.WriteLine(regularGuest);
            }
        }
    }
}
