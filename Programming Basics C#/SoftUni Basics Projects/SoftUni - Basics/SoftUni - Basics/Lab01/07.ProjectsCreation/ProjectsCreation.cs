using System;

namespace _07.ProjectsCreation
{
    class ProjectsCreation
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int projects = int.Parse(Console.ReadLine());
            int projectCrTime = projects * 3;
            Console.WriteLine($"The architect {name} will need {projectCrTime} hours to complete {projects} project/s.");
        }
    }
}
