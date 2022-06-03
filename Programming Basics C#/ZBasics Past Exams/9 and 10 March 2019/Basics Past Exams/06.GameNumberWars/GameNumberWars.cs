using System;

namespace _06.GameNumberWars
{
    class GameNumberWars
    {
        static void Main(string[] args)
        {
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine();
            string end = "End of game";
            string input = null;
            int player1Points = 0;
            int player2Points = 0;

            while (input != end)
            {
                input = Console.ReadLine();

                if (input == end )
                {
                    Console.WriteLine($"{player1} has {player1Points} points");
                    Console.WriteLine($"{player2} has {player2Points} points");
                    return;
                }

                int card1 = int.Parse(input);
                int card2 = int.Parse(Console.ReadLine());
                int difference = 0;

                if (card1 > card2)
                {
                    difference = card1 - card2;
                    player1Points += difference;
                }

                else if (card2 > card1)
                {
                    difference = card2 - card1;
                    player2Points += difference;
                }

                else if (card1 == card2)
                {
                    Console.WriteLine("Number wars!");
                    card1 = int.Parse(Console.ReadLine());
                    card2 = int.Parse(Console.ReadLine());

                    if (card1 > card2)
                    {
                        Console.WriteLine($"{player1} is winner with {player1Points} points");
                    }

                    else if (card2 > card1)
                    {
                        Console.WriteLine($"{player2} is winner with {player2Points} points");
                    }
                    return;
                }
            }
        }
    }
}
