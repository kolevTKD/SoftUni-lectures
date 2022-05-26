using System;

namespace _11.FruitShop
{
    class FruitShop
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double banana = 0;
            double apple = 0;
            double orange = 0;
            double grapefruit = 0;
            double kiwi = 0;
            double pineapple = 0;
            double grapes = 0;

            switch (dayOfWeek)
            {

                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    switch (fruit)
                    {
                        case "banana":
                            banana = 2.5;
                            double bananaPrice = quantity * banana;
                            Console.WriteLine($"{bananaPrice:f2}");
                            break;
                        case "apple":
                            apple = 1.2;
                            double applePrice = quantity * apple;
                            Console.WriteLine($"{applePrice:f2}");
                            break;
                        case "orange":
                            orange = 0.85;
                            double orangePrice = quantity * orange;
                            Console.WriteLine($"{orangePrice:f2}");
                            break;
                        case "grapefruit":
                            grapefruit = 1.45;
                            double grapefruitPrice = quantity * grapefruit;
                            Console.WriteLine($"{grapefruitPrice:f2}");
                            break;
                        case "kiwi":
                            kiwi = 2.70;
                            double kiwiPrice = quantity * kiwi;
                            Console.WriteLine($"{kiwiPrice:f2}");
                            break;
                        case "pineapple":
                            pineapple = 5.5;
                            double pineapplePrice = quantity * pineapple;
                            Console.WriteLine($"{pineapplePrice:f2}");
                            break;
                        case "grapes":
                            grapes = 3.85;
                            double grapesPrice = quantity * grapes;
                            Console.WriteLine($"{grapesPrice:f2}");
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    switch (fruit)
                    {
                        case "banana":
                            banana = 2.7;
                            double bananaPrice = quantity * banana;
                            Console.WriteLine($"{bananaPrice:f2}");
                            break;
                        case "apple":
                            apple = 1.25;
                            double applePrice = quantity * apple;
                            Console.WriteLine($"{applePrice:f2}");
                            break;
                        case "orange":
                            orange = 0.9;
                            double orangePrice = quantity * orange;
                            Console.WriteLine($"{orangePrice:f2}");
                            break;
                        case "grapefruit":
                            grapefruit = 1.6;
                            double grapefruitPrice = quantity * grapefruit;
                            Console.WriteLine($"{grapefruitPrice:f2}");
                            break;
                        case "kiwi":
                            kiwi = 3.0;
                            double kiwiPrice = quantity * kiwi;
                            Console.WriteLine($"{kiwiPrice:f2}");
                            break;
                        case "pineapple":
                            pineapple = 5.6;
                            double pineapplePrice = quantity * pineapple;
                            Console.WriteLine($"{pineapplePrice:f2}");
                            break;
                        case "grapes":
                            grapes = 4.2;
                            double grapesPrice = quantity * grapes;
                            Console.WriteLine($"{grapesPrice:f2}");
                            break;
                        default:
                            Console.WriteLine("error");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
