using System;

namespace _01.OldBooks
{
    class OldBooks
    {
        static void Main(string[] args)
        {
            string favBook = Console.ReadLine();
            string noMoreBooks = "No More Books";
            string nextBook = null;
            int booksChecked = 0;

            while (nextBook != favBook)
            {
                nextBook = Console.ReadLine();

                if (nextBook == noMoreBooks)
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {booksChecked} books.");
                    break;
                }

                if (nextBook == favBook)
                {
                    Console.WriteLine($"You checked {booksChecked} books and found it.");
                }

                booksChecked++;
            }
        }
    }
}
