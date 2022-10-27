using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command = Console.ReadLine();

            while (command != "Tournament")
            {
                string[] playerInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string trainerName = playerInfo[0];
                string pokemonName = playerInfo[1];
                string pokemonElement = playerInfo[2];
                int pokemonHealth = int.Parse(playerInfo[3]);

                Trainer trainer = trainers.SingleOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(trainer);
                }

                else
                {
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    trainer.CheckPokemon(command);
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
