namespace Farm
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Eat();
            dog.Bark();

            Puppy puppy = new Puppy();
            puppy.Weep();
        }
    }
}
