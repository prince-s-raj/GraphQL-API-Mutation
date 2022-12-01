using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLAPI.Models
{
    public class AddSuperPower
    {
        public string SuperPower { get; set; }
        public string? Description { get; set; }

        [ForeignKey("SuperHeroId")]
        public Guid SuperheroId { get; set; }
        public Superhero Superhero { get; set; }
    }
}
