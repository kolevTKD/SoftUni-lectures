namespace _05.FootballTeamGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class StartUp
    {
        private static List<Team> teams;
        static void Main(string[] args)
        {
            teams = new List<Team>();

            RunEngine();
        }

        static void RunEngine()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(';');
                string cmd = cmdArgs[0];
                string teamName = cmdArgs[1];

                try
                {
                    if (cmd == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(team);
                    }
                    else if (cmd == "Add")
                    {
                        AddPlayer(cmdArgs, teamName);
                    }
                    else if (cmd == "Remove")
                    {
                        RemovePlayer(teamName, cmdArgs[2]);
                    }
                    else if (cmd == "Rating")
                    {
                        RateTeam(teamName);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        public static Player CreatePlayer(string[] cmdArgs)
        {
            string playerName = cmdArgs[2];
            int endurance = int.Parse(cmdArgs[3]);
            int sprint = int.Parse(cmdArgs[4]);
            int dribble = int.Parse(cmdArgs[5]);
            int passing = int.Parse(cmdArgs[6]);
            int shooting = int.Parse(cmdArgs[7]);
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            return player;
        }

        public static void AddPlayer(string[] cmdArgs, string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.TEAM_NOT_EXIST, teamName));
            }

            Player player = CreatePlayer(cmdArgs);

            team.AddPlayer(player);
        }

        public static void RemovePlayer(string teamName, string playerName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.TEAM_NOT_EXIST, teamName));
            }

            team.RemovePlayer(playerName);
        }

        public static void RateTeam(string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.TEAM_NOT_EXIST, teamName));
            }

            Console.WriteLine(team);
        }
    }
}
