namespace CustomRandomList
{
using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList rndList = new RandomList() { "a", "b", "c" };
            Console.WriteLine(rndList.RandomString());
        }
    }
}
