using System;

namespace _01._3.GamingStore
{
    class GamingStore
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            string game = "";
            string outfall = "OutFall 4";
            string csog = "CS: OG";
            string zplintrZell = "Zplinter Zell";
            string honored = "Honored 2";
            string roverWatch = "RoverWatch";
            string roverWatchOrigins = "RoverWatch Origins Edition";
            string gameTime = "Game Time";
            double price = 0;
            double totalSpent = 0;


            while (game != gameTime)
            {
                game = Console.ReadLine();

                if (game == gameTime)
                {
                    Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${currentBalance:f2}");
                    return;
                }
                if (game == outfall)
                {
                    price = 39.99;
                }

                else if (game == csog)
                {
                    price = 15.99;
                }

                else if(game == zplintrZell)
                {
                    price = 19.99;
                }

                else if (game == honored)
                {
                    price = 59.99;
                }

                else if(game == roverWatch)
                {
                    price = 29.99;
                }

                else if(game == roverWatchOrigins)
                {
                    price = 39.99;
                }

                else
                {
                    Console.WriteLine("Not Found");
                    continue;
                }

                if (currentBalance - price < 0)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }
                else
                {
                    currentBalance -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {game}");
                }

                if (currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }
        }
    }
}
