using MovieStore.Repository.GenericRepository;
using System.ComponentModel.DataAnnotations;

namespace MovieStore.Models
{
    public class Director : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Profile Picture")]
        public string? ProfilePictureURL { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Biography { get; set; }

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }

}
