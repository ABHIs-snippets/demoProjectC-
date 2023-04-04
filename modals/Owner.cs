namespace demoProject.modals
{
    public class Owner
    {
        public int id { get; set; }
        public string  Name{ get; set; }

        public country country { get; set; }
        public ICollection<Pokemon> pokemons { get; set; }
    }
}
