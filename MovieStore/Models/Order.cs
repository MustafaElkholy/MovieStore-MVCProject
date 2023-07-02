using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        [ForeignKey("AppUser")]
        public string UserId { get; set; }
        public ApplicationUser AppUser { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
