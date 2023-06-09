using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string? GenreName { get; set; }

        public List<MovieGenre> GenreMovies { get; set; } = new List<MovieGenre>();

    }
}
