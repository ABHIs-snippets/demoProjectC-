using demoProject.modals;

namespace demoProject.interfaces
{
    public interface IPokemonRepository
    {
        Task<IEnumerable<Pokemon>> GetPokemons();

        Task<Pokemon?> GetPokemon(int id);

        Task<Pokemon> SetPokemon(Pokemon pokemon);

        Task<Pokemon> DeletePokemon(int id);

        Task<Pokemon> UpdatePokemon(Pokemon pokemon);
    }
}
