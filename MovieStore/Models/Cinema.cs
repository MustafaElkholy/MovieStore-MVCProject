namespace MovieStore.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string? Logo { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<MovieCinema> CinemaMovies { get; set; } = new List<MovieCinema>();

    }
}
