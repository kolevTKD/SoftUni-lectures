namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> data;

        public MyList()
        {
            data = new List<T>();
        }

        public int Used => data.Count;

        public int Add(T element)
        {
            data.Insert(0, element);

            return 0;
        }

        public T Remove()
        {
            T elementToRemove = data.FirstOrDefault();

            if (elementToRemove != null)
            {
                data.Remove(elementToRemove);
            }

            return elementToRemove;
        }
    }
}
