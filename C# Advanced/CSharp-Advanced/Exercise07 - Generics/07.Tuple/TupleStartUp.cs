using System;

namespace _07.Tuple
{
    public class TupleStartUp
    {
        static void Main(string[] args)
        {
            string[] personArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] nameDrinkArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] numbersArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string> personAddress = new Tuple<string, string>
            {
                Item1 = $"{personArgs[0]} {personArgs[1]}",
                Item2 = $"{personArgs[2]}"
            };

            Tuple<string, int> nameDrink = new Tuple<string, int>
            {
                Item1 = $"{nameDrinkArgs[0]}",
                Item2 = int.Parse(nameDrinkArgs[1])
            };

            Tuple<int, double> numbers = new Tuple<int, double>
            {
                Item1 = int.Parse(numbersArgs[0]),
                Item2 = double.Parse(numbersArgs[1])
            };

            Console.WriteLine(personAddress);
            Console.WriteLine(nameDrink);
            Console.WriteLine(numbers);
        }
    }
}
