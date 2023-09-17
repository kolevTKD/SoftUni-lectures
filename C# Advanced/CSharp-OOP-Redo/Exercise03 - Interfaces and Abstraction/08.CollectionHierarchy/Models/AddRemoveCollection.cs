namespace CollectionHierarchy.Models
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> data;

        public AddRemoveCollection()
        {
            data = new List<T>();
        }
        public int Add(T element)
        {
            data.Insert(0, element);

            return 0;
        }

        public T Remove()
        {
            T elementToRemove = data.LastOrDefault();

            if (elementToRemove != null)
            {
                data.Remove(elementToRemove);
            }

            return elementToRemove;
        }
    }
}
