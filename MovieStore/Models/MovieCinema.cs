using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class MovieCinema
    {
        [ForeignKey("Movie")]
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
        [ForeignKey("Cinema")]
        public int? CinemaId { get; set; }
        public Cinema? Cinema { get; set; }
    }
}
