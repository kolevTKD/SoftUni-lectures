using System;

namespace _05.Salary
{
    class Salary
    {
        static void Main(string[] args)
        {
            int tabsOpen = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            int facebook = 150;
            int instagram = 100;
            int reddit = 50;
            int facebookPenalty = 0;
            int instagramPenalty = 0;
            int redditPenalty = 0;
            int totalPenalty = 0;

            for (int i = 1; i <= tabsOpen; i++)
            {
                string website = Console.ReadLine();
                if (website == "Facebook")
                {
                    facebookPenalty += facebook;
                }
                else if (website == "Instagram")
                {
                    instagramPenalty += instagram;
                }
                else if (website == "Reddit")
                {
                    redditPenalty += reddit;
                }
                totalPenalty = facebookPenalty + instagramPenalty + redditPenalty;
                if (salary <= totalPenalty)
                {
                    Console.WriteLine("You have lost your salary.");
                    return;
                }
            }
            int remainder = salary - totalPenalty;
            Console.WriteLine(remainder);
        }
    }
}
