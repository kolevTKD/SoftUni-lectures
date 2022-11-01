using System;
using System.Text;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder animals = new StringBuilder();
            string cmd = Console.ReadLine();

            while (cmd != "Beast!")
            {
                string[] animalInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalInfo[0];
                int age = int.Parse(animalInfo[1]);
                string gender = string.Empty;

                if (animalInfo.Length > 2)
                {
                    gender = animalInfo[2];
                }

                try
                {
                    if (cmd == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        animals.AppendLine(dog.ToString());
                    }

                    else if (cmd == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        animals.AppendLine(frog.ToString());
                    }

                    else if (cmd == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.AppendLine(cat.ToString());
                    }

                    else if (cmd == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.AppendLine(tomcat.ToString());
                    }

                    else if (cmd == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.AppendLine(kitten.ToString());
                    }
                }

                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                cmd = Console.ReadLine();
            }

            Console.WriteLine(animals);
        }
    }
}
