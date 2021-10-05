using System;

namespace pokedexAPI.DTOs
{
    public record PokemonDto
    {
        
        public Guid Id{get;init;}

        public string Name{get;init;}

        public string Height{get;init;}

        public DateTimeOffset CreatedDate{get;set;}
    }
}