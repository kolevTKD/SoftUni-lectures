using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal cat = new Cat("Radka", "Whiskas");
            Animal dog = new Dog("George", "Meat");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());

        }
    }
}
