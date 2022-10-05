using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingLinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        public void AddFirst(Node node)
        {
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }

            Head.Previous = node;
            node.Next = Head;
            Head = node;
            Count++;
        }

        public void AddFirst(int value)
        {
            AddFirst(new Node(value));
        }

        public void AddLast(Node node)
        {
            if (Tail == null)
            {
                Tail = node;
                Head = node;
            }

            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
            Count++;
        }

        public void AddLast(int value)
        {
            AddLast(new Node(value));
        }

        public void RemoveFirst()
        {
            Node oldHead = Head;
            Head = Head.Next;
            Head.Previous = null;
            oldHead.Next = null;
            Count--;
        }

        public void RemoveLast()
        {
            Node oldTail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            oldTail.Previous = null;
            Count--;
        }

        public void ForEach(Action<int> action)
        {
            Node node = Head;

            while (node != null)
            {
                action(node.Value);
                node = node.Next;
            }
        }

        public int[] ToArray()
        {
            int[] linkedListArray = new int[Count];
            int index = 0;

            ForEach(x =>
            {
                linkedListArray[index++] = x;
            });

            return linkedListArray;
        }
    }
}
