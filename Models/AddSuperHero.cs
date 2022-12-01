namespace GraphQLAPI.Models
{
    public class AddSuperHero
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Height { get; set; }
        [UseSorting]
        public ICollection<Superpower> Superpowers { get; set; }
        [UseSorting]
        public ICollection<Movie> Movies { get; set; }
    }
}
