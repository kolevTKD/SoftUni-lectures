namespace BookShop
{
    using Data;
    using Models;

    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Text;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            //DbInitializer.ResetDatabase(context);

            //string input = Console.ReadLine();
            //int lengthCheck = int.Parse(Console.ReadLine());

            Console.WriteLine(GetMostRecentBooks(context));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            List<string> bookTitles = context.Books
                .AsNoTracking()
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        } //02

        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType editionType = Enum.Parse<EditionType>("Gold", true);

            List<string> bookTitles = context.Books
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .Where(b => b.EditionType == editionType && b.Copies < 5000)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        } //03

        public static string GetBooksByPrice(BookShopContext context)
        {

            var books = context.Books
                .AsNoTracking()
                .OrderByDescending(b => b.Price)
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    BookPrice = b.Price
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:F2}");
            }
            return sb.ToString().TrimEnd(); ;
        } //04

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            List<string> bookTitles = context.Books
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => b.Title)
                .ToList();

            return String.Join(Environment.NewLine, bookTitles);
        } //05

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<string> bookTitles = context.Books
                .AsNoTracking()
                .Include(b => b.BookCategories)
                .OrderBy(b => b.Title)
                .Where(b => b.BookCategories.Any(bc => categories.Contains(bc.Category.Name)))
                .Select(b => b.Title)
                .ToList();
                
            return String.Join(Environment.NewLine, bookTitles);
        } //06

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime releaseDate = DateTime.Parse(date);

            var books = context.Books
                .AsNoTracking()
                .OrderByDescending(b => b.ReleaseDate)
                .Where(b => b.ReleaseDate < releaseDate)
                .Select(b => new
                {
                    BookTitle = b.Title,
                    EditionType = b.EditionType.ToString(),
                    BookPrice = b.Price.ToString("F2")

                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach(var book in books)
            {
                sb.AppendLine($"{book.BookTitle} - {book.EditionType} - ${book.BookPrice}");
            }

            return sb.ToString().TrimEnd();
        } //07

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .AsNoTracking()
                .OrderBy(a => a.FirstName)
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach(var author in authors)
            {
                sb.AppendLine(author.FullName);
            }

            return sb.ToString().TrimEnd();
        } //08

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            List<string> bookTitles = context.Books
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, bookTitles);
        } //09

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksAuthors = context.Books
                .AsNoTracking()
                .OrderBy(b => b.BookId)
                .Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var bookAuthor in booksAuthors)
            {
                sb.AppendLine($"{bookAuthor.BookTitle} ({bookAuthor.AuthorFullName})");
            }

            return sb.ToString().TrimEnd();
        } //10

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
           List<Book> books = context.Books
                .AsNoTracking()
                .Where(b => b.Title.Length > lengthCheck)
                .ToList();

            return books.Count;
        } //11

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var booksCopies = context.Authors
                .AsNoTracking()
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    TotalBookCopies = a.Books
                    .Select(b => b.Copies)
                    .Sum()
                })
                .OrderByDescending(a => a.TotalBookCopies)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var bookCopy in booksCopies)
            {
                sb.AppendLine($"{bookCopy.AuthorName} - {bookCopy.TotalBookCopies}");
            }

            return sb.ToString().TrimEnd();
        } //12

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesProfit = context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    TotalProfit = c.CategoryBooks
                    .Select(cb => new
                    {
                        CategoryProfit = cb.Book.Copies * cb.Book.Price
                    })
                    .Sum(cb => cb.CategoryProfit)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoriesProfit)
            {
                sb.AppendLine($"{category.CategoryName} ${category.TotalProfit:F2}");
            }

            return sb.ToString().TrimEnd();
        } //13

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categoryBooks = context.Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    CategoryName = c.Name,
                    Books = c.CategoryBooks
                    .OrderByDescending(b => b.Book.ReleaseDate)
                    .Take(3)
                    .Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        ReleaseYear = b.Book.ReleaseDate!.Value.Year
                    })
                    .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categoryBooks)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.Books)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.ReleaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        } //14

        public static void IncreasePrices(BookShopContext context) //15
        {
            List<Book> books = context.Books
                .Where(b => b.ReleaseDate.HasValue &&
                            b.ReleaseDate!.Value.Year < 2010)
                .ToList();

            foreach (Book book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            List<Book> books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(books);
            context.SaveChanges();

            return books.Count;
        } //16
    }
}