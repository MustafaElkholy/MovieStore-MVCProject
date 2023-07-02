using MovieStore.Models;

namespace MovieStore.Repository.Interface
{
    public interface IOrderRepository
    {
        Task StoreOrder(List<ShoppingCart> items, string userId, string userEmail);
        Task<List<Order>> GetOrderItemsByUserIdAndRole(string userId, string userRole);


    }
}
