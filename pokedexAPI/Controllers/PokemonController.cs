using Microsoft.AspNetCore.Mvc;
using pokedexAPI.DTOs;
using pokedexAPI.Entities;
using pokedexAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pokedexAPI.Controllers
{
    [ApiController]
    [Route("pokemons")]
    public class PokemonController:ControllerBase
    {
        
        ///INTERFACE FOR USE OF DEPENDENCY INJECTION
        public readonly IPokemonRepository repository;

        public PokemonController(IPokemonRepository repository){
            this.repository = repository;
        }

        /// get /pokemons
        [HttpGet]
        public IEnumerable<PokemonDto> getPokemons()
        {

            //USES EXTENSION CLASS TO CONVERT TO DTO
             var pokemons = repository.getPokemons().Select(pokemom => pokemom.AsDto());
             return pokemons;
        }
        /// get /pokemons/{id}
        [HttpGet("{id}")]
        public ActionResult<PokemonDto> getPokemon(Guid id)
        {
            var pokemon = repository.getPokemon(id);
            if(pokemon is null)
            {
                return NotFound();
            }
            return pokemon.AsDto();
        }

        ///Post //pokemons
        [HttpPost]
        public ActionResult<PokemonDto> createPokemon(CreatePokemonDto pokemonDto)
        {
            Pokemon pokemon = new(){
                Id = Guid.NewGuid(),
                Name = pokemonDto.Name,
                Height = pokemonDto.Height,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.createPokemon(pokemon);

            return CreatedAtAction(nameof(getPokemon),new{id=pokemon.Id},pokemon.AsDto());
        }

        /// put{id}
        [HttpPut("{id}")]
        public ActionResult updatePokemon(Guid id, UpdatePokemonDto pokemonDto)
        {
            var exisitingPokemon = repository.getPokemon(id);
            if(exisitingPokemon is null){
                return NotFound();
            }
            Pokemon updatedPokemon  = exisitingPokemon with{
                Name = pokemonDto.Name,
                Height = pokemonDto.Height
            };
            repository.updatePokemon(updatedPokemon);

            return NoContent();
        
        }

        ///delete {id}
        [HttpDelete("{id}")]
        public ActionResult deletePokemon(Guid id)
        {
             var exisitingPokemon = repository.getPokemon(id);
            if(exisitingPokemon is null){
                return NotFound();
            }
            repository.deletePokemon(id);

            return NoContent();
        }
    }
}