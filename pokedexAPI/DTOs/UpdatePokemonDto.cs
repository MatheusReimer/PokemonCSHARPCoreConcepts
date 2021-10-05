using System.ComponentModel.DataAnnotations;

namespace pokedexAPI.DTOs
{
    public record UpdatePokemonDto
    {
        [Required]
        public string Name{get;init;}
        [Required]
        public string Height{get;init;}
    }
}