using System;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();

            Animal animal = new Animal(name);
            Console.WriteLine(animal.Name);

            Mammal mammal = new Mammal(name);
            Console.WriteLine(mammal.Name);

            Bear bear = new Bear(name);
            Console.WriteLine(bear.Name);

            Gorilla gorilla = new Gorilla(name);
            Console.WriteLine(gorilla.Name);

            Reptile reptile = new Reptile(name);
            Console.WriteLine(reptile.Name);

            Snake snake = new Snake(name);
            Console.WriteLine(snake.Name);

            Lizard lizard = new Lizard(name);
            Console.WriteLine(lizard.Name);
        }
    }
}
