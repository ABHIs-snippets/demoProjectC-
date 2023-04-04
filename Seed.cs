using demoProject.Data;
using demoProject.modals;

namespace PokemonReviewApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Owners.Any())
            {
                var pokemonOwners = 
                    new Owner()
                    {
                        Name = "abhi",
                        pokemons = new List<Pokemon>()
                        {
                            new Pokemon()
                            {
                                name = "pikachu",
                                dob = new DateTime(1903,1,1),
                            },
                             new Pokemon()
                            {
                                name = "pikachu 2",
                                dob = new DateTime(1903,2,1),
                            },
                        },

                        country = new country()
                        {
                            name = "Japan"
                        }

                    
                };
                dataContext.Owners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}