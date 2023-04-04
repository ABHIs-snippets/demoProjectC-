using demoProject.modals;
using Microsoft.EntityFrameworkCore;

namespace demoProject.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {
        
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
