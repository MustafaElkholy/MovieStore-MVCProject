using MovieStore.Data;
using MovieStore.Repository.GenericRepository;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class Movie : IEntityBase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public double IMDBRating { get; set; }
        public string IMDBLink { get; set; }
        public string? ImageURL { get; set; }
        public int ReleaseDate { get; set; }
      


        public List<ActorMovie> MovieActors { get; set; } = new List<ActorMovie>();
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

        [ForeignKey("Director")]
        public int? DirectorId { get; set; }
        public Director? Director { get; set; }
        


    

    }
}
