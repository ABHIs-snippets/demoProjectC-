using demoProject.Data;
using demoProject.interfaces;
using demoProject.modals;
using Microsoft.AspNetCore.Mvc;
using System;

namespace demoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class pokemonController : Controller
    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly DataContext context;
        public pokemonController(IPokemonRepository pokemonRepository, DataContext context)
        {
            this.pokemonRepository = pokemonRepository;
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public async Task<ActionResult<IEnumerable<Pokemon>>> GetPokemons()
        {
            var pokemons = await pokemonRepository.GetPokemons();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemons);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pokemon>> GetPokemon()
        {
            var pokemon = await pokemonRepository.GetPokemon(id);
            return Ok(pokemon);
        }
   

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]    
        public async Task<ActionResult<Pokemon>> postPokemon([FromBody] Pokemon pokemon)
        {
            var _pokemon = await pokemonRepository.SetPokemon(pokemon);
            if(_pokemon != null)
            {
                return Ok(_pokemon);
            }
            return BadRequest(new BadRequestResult());
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Pokemon>> DeletePokemon(int id)
        {
           return await pokemonRepository.DeletePokemon(id);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Pokemon>> UpdatePokemon(int id, Pokemon pokemon)
        {
            if(id != pokemon.id)
            {
                return BadRequest("ID is not matched");
            }

            var _pokemon = await pokemonRepository.GetPokemon(id);

            if(_pokemon==null)
            {
                return BadRequest("Pokemon is not find");
            }
            return await pokemonRepository.UpdatePokemon(pokemon);

        }

    }
}
