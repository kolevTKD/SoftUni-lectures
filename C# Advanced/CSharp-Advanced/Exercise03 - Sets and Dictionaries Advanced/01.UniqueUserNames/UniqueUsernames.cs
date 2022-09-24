using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
    internal class UniqueUsernames
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> uniqueUsernames = new HashSet<string>();

            for (int i = 0; i < count; i++)
            {
                string username = Console.ReadLine();
                uniqueUsernames.Add(username);
            }

            foreach (string username in uniqueUsernames)
            {
                Console.WriteLine(username);
            }

            //List<string> uniqueUsernames = new List<string>();

            //for (int i = 0; i < count; i++)
            //{
            //    string username = Console.ReadLine();

            //    if (!uniqueUsernames.Contains(username))
            //    {
            //        uniqueUsernames.Add(username);
            //    }
            //}

            //Console.WriteLine(string.Join(Environment.NewLine, uniqueUsernames));
        }
    }
}
