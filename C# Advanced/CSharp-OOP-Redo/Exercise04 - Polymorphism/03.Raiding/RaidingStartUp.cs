namespace Raiding
{
    using Core;
    using Core.Contracts;
    using Factories;
    using Factories.Contracts;
    using IO;
    using IO.Contracts;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory herofactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, herofactory);
            engine.Run();
        }
    }
}
