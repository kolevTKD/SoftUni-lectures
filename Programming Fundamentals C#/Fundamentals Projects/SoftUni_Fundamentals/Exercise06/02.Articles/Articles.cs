using System;
using System.Linq;

namespace _02.Articles
{
    class Articles
    {
        static void Main(string[] args)
        {
            string[] currentArticle = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int commandsCount = int.Parse(Console.ReadLine());
            Article article = new Article(currentArticle[0], currentArticle[1], currentArticle[2]);

            for (int i = 1; i <= commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                switch (command[0])
                {
                    case "Rename":
                        article.Rename(command[1]);
                        break;
                    case "Edit":
                        article.Edit(command[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(command[1]);
                        break;
                }
            }
            Console.WriteLine(article);
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void Rename(string title) => Title = title;
        public void Edit(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;

        public override string ToString() => $"{Title} - {Content}: {Author}";
    }
}
