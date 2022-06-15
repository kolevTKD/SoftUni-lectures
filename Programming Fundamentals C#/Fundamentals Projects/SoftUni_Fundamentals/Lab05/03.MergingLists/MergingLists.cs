using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class MergingLists
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> list2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> mergedList = new List<int>();

            int biggerList = Math.Max(list1.Count, list2.Count);

            for (int index = 0; index < biggerList; index++)
            {
                if (index < list1.Count)
                {
                    mergedList.Add(list1[index]);
                }

                if (index < list2.Count)
                {
                    mergedList.Add(list2[index]);
                }
            }

            Console.WriteLine(string.Join(" ", mergedList));
        }
    }
}
