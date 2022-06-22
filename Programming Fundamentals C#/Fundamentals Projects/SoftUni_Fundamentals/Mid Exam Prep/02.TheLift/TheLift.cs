using System;
using System.Linq;

namespace _02.TheLift
{
    class TheLift
    {
        static void Main(string[] args)
        {
            int peopleInQueue = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int peoplePerWagon = 4;

            for (int wagon = 0; wagon < lift.Length; wagon++)
            {
                for (int people = lift[wagon]; people < peoplePerWagon; people++)
                {
                    lift[wagon]++;
                    peopleInQueue--;

                    if (peopleInQueue == 0)
                    {
                        if (lift.Sum() < lift.Length * peoplePerWagon)
                        {
                            Console.WriteLine("The lift has empty spots!");
                        }
                        Console.WriteLine(string.Join(' ', lift));

                        return;
                    }
                }
            }
            Console.WriteLine($"There isn't enough space! {peopleInQueue} people in a queue!");
            Console.WriteLine(string.Join(' ', lift));
        }
    }
}
