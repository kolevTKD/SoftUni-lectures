using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            int level = int.Parse(Console.ReadLine());

            Hero hero = new Hero(username, level);
            Console.WriteLine(hero);

            Elf elf = new Elf(username, level);
            Console.WriteLine(elf);

            MuseElf museElf = new MuseElf(username, level);
            Console.WriteLine(museElf);

            Wizard wizard = new Wizard(username, level);
            Console.WriteLine(wizard);

            DarkWizard darkWizard = new DarkWizard(username, level);
            Console.WriteLine(darkWizard);

            SoulMaster soulMaster = new SoulMaster(username, level);
            Console.WriteLine(soulMaster);

            Knight knight = new Knight(username, level);
            Console.WriteLine(knight);

            DarkKnight darkKnight = new DarkKnight(username, level);
            Console.WriteLine(darkKnight);

            BladeKnight bladeKnight = new BladeKnight(username, level);
            Console.WriteLine(bladeKnight);
        }
    }
}
