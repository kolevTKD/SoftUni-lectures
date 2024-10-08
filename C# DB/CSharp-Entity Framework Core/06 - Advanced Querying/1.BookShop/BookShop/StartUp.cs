﻿namespace BookShop
{
    using System.Text;
    using System.Globalization;

    using Microsoft.EntityFrameworkCore;

    using Data;
    using Initializer;
    using Models;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //string input = Console.ReadLine();
            //int lengthCheck = int.Parse(Console.ReadLine());

            //IncreasePrices(db);

            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            List<string> bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> goldenBooks = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, goldenBooks);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var booksByPrice = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByPrice)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            List<string> booksNotReleasedIn = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksNotReleasedIn);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(c => c.ToLower()).ToArray();

            List<string> booksByCategory = context.Books
                .Where(b => b.BookCategories
                    .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, booksByCategory);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksReleasedBefore = context.Books
                .Where(b => b.ReleaseDate < dateTime)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksReleasedBefore)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            List<string> authorNamesEndingIn = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a => $"{a.FirstName} {a.LastName}")
                .ToList();

            return String.Join(Environment.NewLine, authorNamesEndingIn);
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            List<string> bookTitlesContaining = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitlesContaining);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksByAuthor = context.Books
                .Where(b => b.Author.LastName.ToLower()
                    .StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AuthorName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in booksByAuthor)
            {
                sb.AppendLine($"{book.BookTitle} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorCopiesCount = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    CopiesCount = a.Books
                        .Select(b => b.Copies)
                        .Sum()
                })
                .OrderByDescending(b => b.CopiesCount)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach(var author in authorCopiesCount)
            {
                sb.AppendLine($"{author.FullName} - {author.CopiesCount}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesProfit = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    BooksCategories = c.CategoryBooks
                        .Select(cb => new
                        {
                            CategoryProfit = cb.Book
                                .Copies * cb.Book.Price
                        })
                        .Sum(cb => cb.CategoryProfit)
                })
                .OrderByDescending(c => c.BooksCategories)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoriesProfit)
            {
                sb.AppendLine($"{category.CategoryName} ${category.BooksCategories:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                        .OrderByDescending(b => b.Book.ReleaseDate)
                        .Take(3)
                        .Select(b => new
                        {
                            BookName = b.Book.Title,
                            ReleaseDate = b.Book.ReleaseDate.Value.Year
                        })
                        .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in mostRecentBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach(var book in category.Books)
                {
                    sb.AppendLine($"{book.BookName} ({book.ReleaseDate})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            List<Book> selectedBooks = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach(var book in selectedBooks)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            List<Book> booksToBeRemoved = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(booksToBeRemoved);
            context.SaveChanges();

            return booksToBeRemoved.Count();
        }
    }
}


