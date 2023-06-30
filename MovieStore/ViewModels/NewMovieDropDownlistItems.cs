using MovieStore.Models;

namespace MovieStore.ViewModels
{
    public class NewMovieDropDownlistItems
    {
        public NewMovieDropDownlistItems()
        {
            Directors = new List<Director>();
            Generes = new List<Genre>();
            Actors = new List<Actor>();


        }
        public List<Director> Directors { get; set; }
        public List<Genre> Generes { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
