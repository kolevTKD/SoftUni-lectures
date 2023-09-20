namespace Cards
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] deckInfo = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);


            foreach (string element in deckInfo)
            {
                try
                {
                    string[] cardInfo = element.Split(' ');
                    string face = cardInfo[0];

                    if (!char.TryParse(cardInfo[1], out char suite))
                    {
                        throw new ArgumentException();
                    }

                    Card card = CreateCard(face, suite);
                    cards.Add(card);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            if (cards.Count > 0)
            {
                Console.WriteLine(String.Join(" ", cards));
            }
        }

        public static Card CreateCard(string face, char suite)
        {
            HashSet<string> faces = new HashSet<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A", };
            Dictionary<char, char> suites = new Dictionary<char, char>()
            {
                {'S', '\u2660'}, //Spades
                {'H', '\u2665'}, //Hearts
                {'D', '\u2666'}, //Diamonds
                {'C', '\u2663'}, //Clubs
            };

            if (!faces.Contains(face) || !suites.ContainsKey(suite))
            {
                throw new ArgumentException();
            }

            Card card = new Card(face, suites[suite]);

            return card;
        }
    }

    public class Card
    {
        public Card(string face, char suite)
        {
            Face = face;
            Suite = suite;
        }

        public string Face { get; private set; }
        public char Suite { get; private set; }

        public override string ToString() => $"[{Face}{Suite}]";
    }
}
