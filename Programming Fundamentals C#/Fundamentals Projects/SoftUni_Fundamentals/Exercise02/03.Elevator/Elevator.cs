using System;

namespace _03.Elevator
{
    class Elevator
    {
        static void Main(string[] args)
        {
            int peopleNum = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)peopleNum / capacity);

            Console.WriteLine(courses);
        }
    }
}
