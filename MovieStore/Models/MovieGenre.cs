using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class MovieGenre
    {
        [ForeignKey("Movie")]
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }

        [ForeignKey("Genre")]
        public int? GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
