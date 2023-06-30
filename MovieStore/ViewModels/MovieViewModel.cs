using System.ComponentModel.DataAnnotations;

namespace MovieStore.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Movie Name Is Required")]
        public string Name { get; set; }

        [Display(Name = "Movie Plot")]
        [Required(ErrorMessage = "Description Is Required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price Is Required")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster")]
        [Required(ErrorMessage = "Movie Poster Is Required")]
        public string ImageURL { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "Release Date Is Required")]
        public int ReleaseDate { get; set; }

        //Relationships


        [Display(Name = "Select Genere(s)")]
        [Required(ErrorMessage = "Movie Genere(s) Is Required")]
        public List<int>? GenereId { get; set; }

        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Movie actor(s) Is Required")]
        public List<int>? ActorIds { get; set; }


        [Display(Name = "Select a Director")]
        [Required(ErrorMessage = "Movie Director Is Required")]
        public int? DirectorId { get; set; }
    }
}
