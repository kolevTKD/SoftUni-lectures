using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class TheVlogger
    {
        static void Main(string[] args)
        {
            List<Vlogger> theVloggers = new List<Vlogger>();
            
            string end = "Statistics";
            string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (cmdArgs[0] != end)
            {
                string vloggerName = cmdArgs[0];
                string cmd = cmdArgs[1];

                if (cmd == "joined" && cmdArgs.Length == 4)
                {
                    if (!theVloggers.Any(v => v.VloggerName == vloggerName))
                    {
                        theVloggers.Add(new Vlogger(vloggerName));
                    }
                }

                else if (cmd == "followed")
                {
                    string secondVloggerName = cmdArgs[2];

                    if (theVloggers.Any(x => x.VloggerName == vloggerName) && theVloggers.Any(x => x.VloggerName == secondVloggerName) && vloggerName != secondVloggerName)
                    {
                        Vlogger vlogger = theVloggers.Single(x => x.VloggerName == vloggerName);
                        vlogger.Following.Add(secondVloggerName);

                        Vlogger secondVlogger = theVloggers.Single(x => x.VloggerName == secondVloggerName);
                        secondVlogger.Followers.Add(vloggerName);
                    }
                }

                cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"The V-Logger has a total of {theVloggers.Count} vloggers in its logs.");

            int count = 1;
            theVloggers = theVloggers.OrderByDescending(x => x.Followers.Count).ThenBy(x => x.Following.Count).ToList();

            foreach (var vlogger in theVloggers)
            {
                Console.WriteLine($"{count}. {vlogger.VloggerName} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");

                if (count == 1)
                {
                    foreach (var follower in vlogger.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                count++;
            }

        }
    }

    class Vlogger
    {
        public Vlogger(string vloggerName)
        {
            VloggerName = vloggerName;
            Followers = new SortedSet<string>();
            Following = new HashSet<string>();
        }
        public string VloggerName { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}
