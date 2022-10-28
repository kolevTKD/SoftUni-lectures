using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodIntegers
{
    public class Box<T>
    {
        public Box()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }

        public void Swap(int index1, int index2)
        {
            T temp = Items[index1];
            Items[index1] = Items[index2];
            Items[index2] = temp;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in Items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
