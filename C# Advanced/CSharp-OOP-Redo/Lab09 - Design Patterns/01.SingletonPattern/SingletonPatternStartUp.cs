namespace SingletonPattern
{
    using System;
    using SingletonPattern.Models;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("Washington, D.C."));

            var db2 = SingletonDataContainer.Instance;
            Console.WriteLine(db.GetPopulation("London"));
        }
    }
}
