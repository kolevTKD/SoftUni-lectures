using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonDon_tGo
{
    class PokemonDontGo
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumOfRemoved = 0;
            int removedElement = 0;
            int indexToRemove = 0;

            while (distances.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    indexToRemove = 0;
                    sumOfRemoved += distances[0];
                    removedElement = distances[0];
                    distances.RemoveAt(indexToRemove);
                    distances.Insert(0, distances[distances.Count - 1]);
                }

                else if (index > distances.Count - 1)
                {
                    indexToRemove = distances.Count - 1;
                    sumOfRemoved += distances[distances.Count - 1];
                    removedElement = distances[distances.Count - 1];
                    distances.RemoveAt(indexToRemove);
                    distances.Insert(distances.Count, distances[0]);
                }

                else
                {
                    indexToRemove = index;
                    sumOfRemoved += distances[index];
                    removedElement = distances[index];
                    distances.RemoveAt(indexToRemove);
                }

                for (int i = 0; i < distances.Count; i++)
                {
                    if (distances[i] <= removedElement)
                    {
                        distances[i] += removedElement;
                    }

                    else if (distances[i] > removedElement)
                    {
                        distances[i] -= removedElement;
                    }
                }
            }
            Console.WriteLine(sumOfRemoved);
        }
    }
}
