using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    internal class SoftUniExamResults
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();

            while (true)
            {
                string[] submissionInfo = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
                string participantName = submissionInfo[0];

                if (submissionInfo[0] == "exam finished")
                {
                    break;
                }

                if (submissionInfo[1] == "banned")
                {
                    participants.Remove(participantName);
                    continue;
                }

                string languageName = submissionInfo[1];
                int points = int.Parse(submissionInfo[2]);

                if (!participants.ContainsKey(participantName))
                {
                    participants.Add(participantName, 0);
                }

                if (participants[participantName] < points)
                {
                    participants[participantName] = points;
                }

                if (!languages.ContainsKey(languageName))
                {
                    languages.Add(languageName, 0);
                }

                languages[languageName]++;
            }

            participants = participants
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Results:");

            foreach (KeyValuePair<string, int> participant in participants)
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            languages = languages
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            Console.WriteLine("Submissions:");

            foreach (KeyValuePair<string, int> language in languages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
