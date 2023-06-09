using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class ActorMovie
    {
        [ForeignKey("Actor")]
        public int? ActorId { get; set; }
        public Actor? Actor { get; set; }
        [ForeignKey("Movie")]
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
