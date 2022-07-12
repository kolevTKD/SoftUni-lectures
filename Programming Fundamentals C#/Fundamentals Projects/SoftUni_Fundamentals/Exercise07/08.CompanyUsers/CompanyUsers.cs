using System;
using System.Collections.Generic;

namespace _08.CompanyUsers
{
    class CompanyUsers
    {
        static void Main(string[] args)
        {
            string[] companyUserId = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            string end = "End";
            Dictionary<string, List<string>> companyEmployes = new Dictionary<string, List<string>>();

            while (companyUserId[0] != end)
            {
                string company = companyUserId[0];
                string user = companyUserId[1];

                if (!companyEmployes.ContainsKey(company))
                {
                    companyEmployes.Add(company, new List<string>());
                }

                if (!companyEmployes[company].Contains(user))
                {
                    companyEmployes[company].Add(user);
                }

                companyUserId = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var company in companyEmployes)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
