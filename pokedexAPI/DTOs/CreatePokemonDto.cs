using System.ComponentModel.DataAnnotations;

namespace pokedexAPI.DTOs
{
    public record CreatePokemonDto
    {
        [Required]
        public string Name{get;init;}
        [Required]
        public string Height{get;init;}
    }
}