using System;

namespace _01.AdvertisementMessage
{
    class AdvertisementMessage
    {
        static void Main(string[] args)
        {
            int inputNum = int.Parse(Console.ReadLine());
            string[] phrases = { "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product." };

            string[] events = { "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!" };

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random random = new Random();

            for (int phrase = 1; phrase <= inputNum; phrase++)
            {
                int randPhrase = random.Next(phrases.Length);
                int randEvent = random.Next(events.Length);
                int randAuthor = random.Next(authors.Length);
                int randCity = random.Next(cities.Length);

                Console.WriteLine($"{phrases[randPhrase]} {events[randEvent]} {authors[randAuthor]} - {cities[randCity]}.");
            }
        }
    }
}
