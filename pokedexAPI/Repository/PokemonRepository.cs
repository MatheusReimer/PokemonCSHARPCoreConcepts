using System;
using System.Collections.Generic;
using pokedexAPI.Entities;
using System.Linq;


namespace pokedexAPI.Repository

{
    public class PokemonRepository : IPokemonRepository
    {
        
        private readonly List<Pokemon> pokemons = new()
        {
            new Pokemon { Id = Guid.NewGuid(), Name = "Ditto", Height = "1.2m", CreatedDate = DateTimeOffset.UtcNow },
            new Pokemon { Id = Guid.NewGuid(), Name = "Pikachu", Height = "0.8m", CreatedDate = DateTimeOffset.UtcNow }

        };



        public Pokemon getPokemon(Guid id)
        {
            return pokemons.Where(pokemons => pokemons.Id == id).SingleOrDefault();
        }

        public List<Pokemon> getPokemons()
        {
            return pokemons;
        }

        public void createPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }

        public void updatePokemon(Pokemon pokemon)
        {
            var index = pokemons.FindIndex(exsistingPokemon => exsistingPokemon.Id == pokemon.Id);
            pokemons[index] = pokemon;


        }

        public void deletePokemon(Guid id)
        {
            var index = pokemons.FindIndex(exsistingPokemon => exsistingPokemon.Id == id);
            pokemons.RemoveAt(index); 
        }
    }
}