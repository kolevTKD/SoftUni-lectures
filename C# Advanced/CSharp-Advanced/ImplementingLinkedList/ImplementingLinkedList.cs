using System;

namespace ImplementingLinkedList
{
    internal class ImplementingLinkedList
    {
        static void Main(string[] args)
        {
            LinkedList linkedList = new LinkedList();

            for (int num = 1; num <= 10; num++)
            {
                if (num > 5)
                {
                    linkedList.AddFirst(num);
                    continue;
                }

                linkedList.AddLast(num);
            }

            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            linkedList.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();
            Console.WriteLine(linkedList.Count);
        }
    }
}
