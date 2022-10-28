using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDoubles
{
    public class Box<T> where T : IComparable<T>
    {
        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public int GetCount(T itemToCompare)
        {
            int count = 0;

            foreach (T item in Items)
            {
                if (itemToCompare.CompareTo(item) < 0)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
