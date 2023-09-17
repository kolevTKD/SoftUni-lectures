namespace CollectionHierarchy.Core
{
    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            IAddCollection<string> addCollection = new AddCollection<string>();
            IAddRemoveCollection<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myList = new MyList<string>();

            string[] elementsToAdd = reader.ReadLine().Split(' ');
            int removeOperationsCount = int.Parse(reader.ReadLine());

            AddToCollection(addCollection, elementsToAdd);
            AddToCollection(addRemoveCollection, elementsToAdd);
            AddToCollection(myList, elementsToAdd);

            RemoveFromCollection(addRemoveCollection, removeOperationsCount);
            RemoveFromCollection(myList, removeOperationsCount);
        }

        private void AddToCollection(IAddCollection<string> collection, string[] elementsToAdd)
        {
            foreach (string element in elementsToAdd)
            {
                writer.Write(collection.Add(element) + " ");
            }

            writer.WriteLine(string.Empty);
        }

        private void RemoveFromCollection(IAddRemoveCollection<string> collection, int removeOperationsCount)
        {
            for (int i = 0; i < removeOperationsCount; i++)
            {
                writer.Write(collection.Remove() + " ");
            }

            writer.WriteLine(string.Empty);
        }
    }
}
