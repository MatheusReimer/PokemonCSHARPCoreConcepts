using pokedexAPI.DTOs;
using pokedexAPI.Entities;

namespace pokedexAPI
{

    ///INSTEAD OF CONVERTING MANUALLY EVERYTIME, WE JUST USE EXTENSIONS TO CONVERT FOR US
    public static class Extensions
    {
        public static PokemonDto AsDto(this Pokemon pokemon)
        {
            return new PokemonDto{
                 Id = pokemon.Id,
                 Name = pokemon.Name,
                 Height = pokemon.Height,
                 CreatedDate = pokemon.CreatedDate
             };
        }
    }
}