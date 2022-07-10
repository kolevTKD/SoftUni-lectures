using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Articles2
    {
        static void Main(string[] args)
        {
            int articlesNum = int.Parse(Console.ReadLine());
            List<Article> newsletter = new List<Article>();

            for (int i = 1; i <= articlesNum; i++)
            {
                string[] articles = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Article article = new Article(articles[0], articles[1], articles[2]);
                newsletter.Add(article);
            }
            Console.ReadLine();

            foreach (Article article in newsletter)
            {
                Console.WriteLine(article);
            }
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

        public override string ToString() => $"{Title} - {Content}: {Author}";
    }
}
