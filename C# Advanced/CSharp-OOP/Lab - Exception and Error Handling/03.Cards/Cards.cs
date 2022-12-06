namespace Cards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cards
    {
        static void Main(string[] args)
        {
            string[] deckInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cardDeck = new List<Card>();

            for (int i = 0; i < deckInput.Length; i++)
            {
                try
                {
                    string[] currentCard = deckInput[i].Split(' ');
                    string face = currentCard[0];
                    string suit = currentCard[1];

                    cardDeck.Add(CreateCard(face, suit));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid card!");
                }
            }

            Console.WriteLine(string.Join(' ', cardDeck));
        }

        public static Card CreateCard(string face, string suitAsString)
        {
            string[] validFaces = new string[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuits = new string[] { "S", "H", "D", "C" };

            if (!validFaces.Contains(face) || !validSuits.Contains(suitAsString))
            {
                throw new ArgumentException();
            }

            char suit = char.Parse(suitAsString);

            Card card = new Card(face, suit);

            return card;
        }
    }

    public class Card
    {
        private char suit;

        public const char SPADES = '\u2660';
        public const char HEARTHS = '\u2665';
        public const char DIAMONDS = '\u2666';
        public const char CLUBS = '\u2663';
        public Card(string face, char suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face { get; set; }
        public char Suit
        {
            get => this.suit;
            set
            {
                if (value == 'S')
                {
                    value = SPADES;
                }

                else if (value == 'H')
                {
                    value = HEARTHS;
                }

                else if (value == 'D')
                {
                    value = DIAMONDS;
                }

                else if (value == 'C')
                {
                    value = CLUBS;
                }

                this.suit = value;
            }
        }

        public override string ToString() => $"[{this.Face}{this.Suit}]";
    }
}
