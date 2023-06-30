using MovieStore.Repository.GenericRepository;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Cinema : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public string? Logo { get; set; }
        
        [Required]
        public string? Name { get; set; }
        [Required]

        public string? Description { get; set; }
        [Required]
        public string? Location { get; set; }
        public List<MovieCinema> CinemaMovies { get; set; } = new List<MovieCinema>();

    }
}
