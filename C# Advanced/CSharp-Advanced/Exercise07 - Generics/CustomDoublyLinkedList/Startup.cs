using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class Startup
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> linkedList = new DoublyLinkedList<int>();

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
