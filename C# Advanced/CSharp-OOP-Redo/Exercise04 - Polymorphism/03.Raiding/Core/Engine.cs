namespace Raiding.Core
{
    using System.Collections.Generic;

    using Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IBaseHero> heroes;

        private Engine()
        {
            heroes = new HashSet<IBaseHero>();
        }
        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
        }
        public void Run()
        {
            int lines = int.Parse(reader.ReadLine());

            while (heroes.Count < lines)
            {
                try
                {
                    ProcessCommand();
                }
                catch (InvalidHeroException ihe)
                {
                    writer.WriteLine(ihe.Message);
                }
            }

            int bossPower = int.Parse(reader.ReadLine());

            BossFight(bossPower);
        }

        private void ProcessCommand()
        {
            string name = reader.ReadLine();
            string type = reader.ReadLine();

            heroes.Add(heroFactory.CreateHero(name, type));
        }

        private void BossFight(int bossPower)
        {
            int heroesPower = 0;
            string message = string.Empty;

            foreach (IBaseHero hero in heroes)
            {
                writer.WriteLine(hero.CastAbility());
                heroesPower += hero.Power;
            }

            if (heroesPower >= bossPower)
            {
                message = "Victory!";
            }
            else
            {
                message = "Defeat...";
            }

            writer.WriteLine(message);
        }
    }
}
