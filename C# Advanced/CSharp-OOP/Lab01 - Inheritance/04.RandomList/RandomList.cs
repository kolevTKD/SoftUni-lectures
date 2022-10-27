using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList<T> : List<T>
    {
        private Random random;

        public RandomList()
        {
            random = new Random();
        }
        public T RandomString()
        {
            int index = random.Next(0, this.Count);
            T removed = this[index];
            this.RemoveAt(index);

            return removed;
        }
    }
}
