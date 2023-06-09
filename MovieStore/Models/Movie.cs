using MovieStore.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        //public MovieCategory Genre { get; set; }

        public List<ActorMovie> MovieActors { get; set; } = new List<ActorMovie>();
        public List<MovieCinema> MovieCinemas { get; set; } = new List<MovieCinema>();
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();

        [ForeignKey("Director")]
        public int DirectorId { get; set; }
        public Director? Director { get; set; }
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public Producer? Producer { get; set; }



    }
}
