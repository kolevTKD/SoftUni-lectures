using System;

namespace _04.Walking
{
    class Walking
    {
        static void Main(string[] args)
        {
            string goingHome = "Going home";
            int goalSteps = 10000;
            int totalSteps = 0;
            int steps = 0;

            while (totalSteps < goalSteps)
            {
                string input = Console.ReadLine();

                if (input == goingHome)
                {
                    steps = int.Parse(Console.ReadLine());
                    totalSteps += steps;
                    break;
                }

                steps = int.Parse(input);
                totalSteps += steps;
            }

            if (totalSteps >= goalSteps)
            {
                int stepsOver = totalSteps - goalSteps;
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsOver} steps over the goal!");
            }

            else
            {
                int stepsNeeded = goalSteps - totalSteps;
                Console.WriteLine($"{stepsNeeded} more steps to reach goal.");
            }
        }
    }
}
