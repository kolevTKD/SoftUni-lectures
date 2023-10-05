namespace SingletonPattern.Models
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using Contracts;

    public class SingletonDataContainer : ISingletonContainer
    {
        private IDictionary<string, int> capitals;
        private static SingletonDataContainer instance = new SingletonDataContainer();

        private SingletonDataContainer()
        {
            capitals = new Dictionary<string, int>();

            Console.WriteLine("Initializing singleton object");

            string[] elements = File.ReadAllLines("../../../capitals.txt");

            for (int i = 0; i < elements.Length; i += 2)
            {
                capitals.Add(elements[i], int.Parse(elements[i + 1]));
            }
        }

        public static SingletonDataContainer Instance => instance;

        public int GetPopulation(string name) => capitals[name];
    }
}
