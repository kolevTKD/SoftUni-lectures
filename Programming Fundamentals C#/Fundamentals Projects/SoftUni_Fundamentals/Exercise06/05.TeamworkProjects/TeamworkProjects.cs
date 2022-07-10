using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    class TeamworkProjects
    {
        static void Main(string[] args)
        {
            int teamsCount = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            for (int currTeam = 1; currTeam <= teamsCount; currTeam++)
            {
                string[] creatorTeam = Console.ReadLine().Split('-').ToArray();
                string creatorName = creatorTeam[0];
                string teamName = creatorTeam[1];


                if (teams.Any(team => team.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }

                else if (teams.Any(creator => creator.CreatorName == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }

                else
                {
                    Team team = new Team();
                    team.CreatorName = creatorName;
                    team.TeamName = teamName;
                    team.Members = new List<string>();
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
            }

            string end = "end of assignment";
            string[] actions = Console.ReadLine().Split("->").ToArray();

            while (actions[0] != end)
            {
                string memberName = actions[0];
                string teamName = actions[1];

                if (!teams.Any(team => team.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                else if (teams.Any(team => team.Members.Contains(memberName)) || teams.Any(creator => creator.CreatorName == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                }

                else
                {
                    Team currentTeam = teams.Find(team => team.TeamName == teamName);
                    currentTeam.Members.Add(memberName);
                }

                actions = Console.ReadLine().Split("->").ToArray();
            }

            var completedTeams = teams.Where(members => members.Members.Count > 0);
            var teamsToDisband = teams.Where(members => members.Members.Count == 0);

            foreach (Team team in completedTeams.OrderByDescending(team => team.Members.Count).ThenBy(team => team.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.CreatorName}");

                foreach (var member in team.Members.OrderBy(member => member))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine("Teams to disband:");

            foreach (Team team in teamsToDisband.OrderBy(team => team.TeamName))
            {
                Console.WriteLine(team.TeamName);
            }
        }
    }

    class Team
    {
        public string CreatorName { get; set; }
        public string TeamName { get; set; }
        public List<string> Members { get; set; }
    }
}
