namespace MovieStore.Models
{
    public class Producer
    {
        public int Id { get; set; }
        public string? ProfilePictureURL { get; set; }
        public string? FullName { get; set; }
        public string? Biography { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();

    }
}
