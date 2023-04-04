using demoProject.Data;
using demoProject.interfaces;
using demoProject.modals;
using Microsoft.EntityFrameworkCore;

namespace demoProject.repositories
{
    public class pokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public pokemonRepository(DataContext context) {
            _context = context;
        }

        public async Task<Pokemon> DeletePokemon(int id)
        {
            var pokemon = await  _context.Pokemons.Where(p => p.id == id).FirstOrDefaultAsync();
            if(pokemon != null)
            {
                _context.Pokemons.Remove(pokemon);
                await _context.SaveChangesAsync();
                return pokemon;
            }
            return null;

        }

        public async Task<Pokemon?> GetPokemon(int id)
        {
            var result = await _context.Pokemons.FirstOrDefaultAsync(p => p.id == id);
            if (result == null) return null;
            return result;
        }

        public async Task<IEnumerable<Pokemon>> GetPokemons() {

            return await _context.Pokemons.OrderBy(p=>p.id).ToListAsync();
                }

        public async Task<Pokemon> SetPokemon(Pokemon pokemon )
        {
            var result = await _context.Pokemons.AddAsync( pokemon );
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Pokemon> UpdatePokemon(Pokemon pokemon)
        {
            var result = await _context.Pokemons.FirstOrDefaultAsync(p=>p.id == pokemon.id);
            if(result!=null)
            {
                result.name = pokemon.name;
                result.dob = pokemon.dob;
                await _context.SaveChangesAsync();  
                return result;
            }
            return null;
        }
    }
}
