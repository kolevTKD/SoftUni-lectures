using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._1.Ranking
{
    internal class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsInfo = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> userContests = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string[] info = Console.ReadLine().Split(':');

                if (info[0] == "end of contests")
                {
                    break;
                }

                string contestName = info[0];
                string contestPassword = info[1];

                if (!contestsInfo.ContainsKey(contestName))
                {
                    contestsInfo.Add(contestName, contestPassword);
                }
            }

            while (true)
            {
                string[] submissionInfo = Console.ReadLine().Split("=>");

                if (submissionInfo[0] == "end of submissions")
                {
                    break;
                }

                string contestName = submissionInfo[0];
                string contestPassword = submissionInfo[1];
                string candidateName = submissionInfo[2];
                int points = int.Parse(submissionInfo[3]);

                foreach (var contest in contestsInfo)
                {
                    if (contest.Key == contestName && contest.Value == contestPassword)
                    {
                        if (!userContests.ContainsKey(candidateName))
                        {
                            userContests.Add(candidateName, new Dictionary<string, int>());
                        }

                        if (userContests.ContainsKey(candidateName))
                        {
                            if (!userContests[candidateName].ContainsKey(contestName))
                            {
                                userContests[candidateName].Add(contestName, points);
                            }

                            else
                            {
                                if (points > userContests[candidateName][contestName])
                                {
                                    userContests[candidateName][contestName] = points;
                                }
                            }
                        }
                    }
                }
            }

            string bestCandidateName = "";
            int bestCandidatePoints = 0;

            foreach (var candidate in userContests)
            {
                int totalPoints = 0;

                foreach (var contest in candidate.Value)
                {
                    totalPoints += contest.Value;
                }

                if (totalPoints > bestCandidatePoints)
                {
                    bestCandidateName = candidate.Key;
                    bestCandidatePoints = totalPoints;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidateName} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var candidate in userContests)
            {
                Console.WriteLine(candidate.Key);

                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
