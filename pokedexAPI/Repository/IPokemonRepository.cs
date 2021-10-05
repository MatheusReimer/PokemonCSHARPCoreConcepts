using pokedexAPI.Entities;
using System;
using System.Collections.Generic;

namespace pokedexAPI.Repository
{
    public interface IPokemonRepository
    {
        List<Pokemon> getPokemons();
        Pokemon getPokemon(Guid id);

        void createPokemon(Pokemon pokemon);

        void updatePokemon(Pokemon pokemon);

        void deletePokemon(Guid id);
    }
}