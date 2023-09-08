namespace Animals
{
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder animals = new StringBuilder();
            string cmd = string.Empty;

            while ((cmd = Console.ReadLine()) != "Beast!")
            
            {
                string animalType = cmd;
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
                    if (animalType == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        animals.AppendLine(dog.ToString());
                    }
                    else if (animalType == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.AppendLine(cat.ToString());
                    }
                    else if (animalType == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        animals.AppendLine(frog.ToString());
                    }
                    else if (animalType == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.AppendLine(kitten.ToString());
                    }
                    else if (animalType == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.AppendLine(tomcat.ToString());
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(animals.ToString().Trim());
        }
    }
}
