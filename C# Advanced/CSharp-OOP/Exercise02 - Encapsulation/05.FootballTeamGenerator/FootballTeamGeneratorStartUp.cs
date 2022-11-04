using System;
using System.Collections.Generic;
using System.Linq;
using _05.FootballTeamGenerator.Models;

namespace _05.FootballTeamGenerator
{
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
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = input.Split(';');
                string cmd = cmdArgs[0];
                string teamName = cmdArgs[1];

                try
                {


                    if (cmd == "Team")
                    {
                        AddTeam(teamName);
                    }

                    else if (cmd == "Add")
                    {
                        AddPlayer(teamName, cmdArgs);
                    }

                    else if (cmd == "Remove")
                    {
                        string playerName = cmdArgs[2];
                        RemovePlayer(teamName, playerName);
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
                catch (InvalidOperationException ioa)
                {
                    Console.WriteLine(ioa.Message);
                }
            }
        }

        static void AddTeam(string teamName)
        {
            Team team = new Team(teamName);
            teams.Add(team);
        }

        static void AddPlayer(string teamName, string[] cmdArgs)
        {
            Team teamToJoin = teams.FirstOrDefault(t => t.Name == teamName);

            if (teamToJoin == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.TEAM_NOT_EXISTING, teamName));
            }

            Player joiningPlayer = CreatePlayer(cmdArgs);
            teamToJoin.AddPLayer(joiningPlayer);
        }

        static Player CreatePlayer(string[] cmdArgs)
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

        static void RemovePlayer(string teamName, string playerName)
        {
            Team removingTeam = teams.FirstOrDefault(t => t.Name == teamName);

            if (removingTeam == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.TEAM_NOT_EXISTING, teamName));
            }

            removingTeam.RemovePlayer(playerName);
        }

        static void RateTeam(string teamName)
        {
            Team teamToRate = teams.FirstOrDefault(t => t.Name == teamName);

            if (teamToRate == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.TEAM_NOT_EXISTING, teamName));
            }

            Console.WriteLine(teamToRate);
        }
    }
}
