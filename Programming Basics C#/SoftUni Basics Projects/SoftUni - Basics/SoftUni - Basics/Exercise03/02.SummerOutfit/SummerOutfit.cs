using System;

namespace _02.SummerOutfit
{
    class SummerOutfit
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string timeOfDay = Console.ReadLine();
            string outfit = null;
            string shoes = null;
            bool degrees10to18 = degrees >= 10 && degrees <= 18;
            bool degrees18to24 = degrees > 18 && degrees <= 24;
            bool degreesGreater25 = degrees >= 25 && degrees <= 42;

            switch (degrees10to18)
            {
                case true:
                    switch (timeOfDay)
                    {
                        case "Morning":
                            outfit = "Sweatshirt";
                            shoes = "Sneakers";
                            break;
                        case "Afternoon":
                        case "Evening":
                            outfit = "Shirt";
                            shoes = "Moccasins";
                            break;
                    }
                    break;
            }
            switch (degrees18to24)
            {
                case true:
                    switch (timeOfDay)
                    {
                        case "Morning":
                            outfit = "Shirt";
                            shoes = "Moccasins";
                            break;
                        case "Afternoon":
                            outfit = "T-Shirt";
                            shoes = "Sandals";
                            break;
                        case "Evening":
                            outfit = "Shirt";
                            shoes = "Moccasins";
                            break;
                    }
                    break;
            }
            switch (degreesGreater25)
            {
                case true:
                    switch (timeOfDay)
                    {
                        case "Morning":
                            outfit = "T-Shirt";
                            shoes = "Sandals";
                            break;
                        case "Afternoon":
                            outfit = "Swim Suit";
                            shoes = "Barefoot";
                            break;
                        case "Evening":
                            outfit = "Shirt";
                            shoes = "Moccasins";
                            break;
                    }
                    break;
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
