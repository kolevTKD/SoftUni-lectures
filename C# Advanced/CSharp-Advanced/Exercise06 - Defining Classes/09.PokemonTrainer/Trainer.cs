using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public Trainer(string name)
        {
            Name = name;
            NumberOfBadges = 0;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get { return this.name; } set { this.name = value; } }
        public int NumberOfBadges { get { return this.numberOfBadges; } set { this.numberOfBadges = value; } }
        public List<Pokemon> Pokemons { get { return this.pokemons; } set { this.pokemons = value; } }

        public void CheckPokemon(string element)
        {
            if (Pokemons.Any(p => p.Element == element))
            {
                NumberOfBadges++;
            }

            else
            {
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    Pokemon pokemon = this.Pokemons[i];
                    pokemon.Health -= 10;
                }
            }

            this.Pokemons.RemoveAll(p => p.Health <= 0);
        }
    }
}
