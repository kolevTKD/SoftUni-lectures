namespace Raiding.Core
{
    using System.Collections.Generic;

    using Core.Contracts;
    using Exceptions;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IHero> raidTeam;

        private Engine()
        {
            this.raidTeam = new HashSet<IHero>();
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
            int raidMembersCount = int.Parse(this.reader.ReadLine());

            while(this.raidTeam.Count < raidMembersCount)
            {
                try
                {
                    this.ProcessCommand();
                }
                catch (InvalidHeroException ihe)
                {
                    this.writer.WriteLine(ihe.Message);
                }
            }

            int bossHP = int.Parse(this.reader.ReadLine());

            this.CastAbility(bossHP);
        }

        private IHero CreateHeroViaFactory(string heroName, string heroType) => this.heroFactory.CreateHero(heroName, heroType);

        private void ProcessCommand()
        {
            string currHeroName = this.reader.ReadLine();
            string currHeroType = this.reader.ReadLine();
            //will need testing for exception throws***

            this.raidTeam.Add(CreateHeroViaFactory(currHeroName, currHeroType));
        }

        private void CastAbility(int bossHP)
        {
            int abilitiesSum = 0;

            foreach (IHero hero in this.raidTeam)
            {
                abilitiesSum += hero.Power;
                this.writer.WriteLine(hero.CastAbility());
            }

            if (abilitiesSum >= bossHP)
            {
                this.writer.WriteLine("Victory!");
            }

            else
            {
                this.writer.WriteLine("Defeat...");
            }
        }
    }
}
