using Microsoft.AspNetCore.Mvc;
using MovieStore.Data.ShoppingCartData;
using MovieStore.Models;
using MovieStore.Repository.Interface;
using MovieStore.ViewModels;

namespace MovieStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMovieRepository movieRepo;
        private readonly IOrderRepository orderRepo;
        private readonly CartData shoppingCart;

        public OrderController(IMovieRepository movieRepo, CartData shoppingCart, IOrderRepository orderRepo)
        {
            this.movieRepo = movieRepo;
            this.shoppingCart = shoppingCart;
            this.orderRepo = orderRepo;
        }
        public IActionResult Index()
        {
            var items = shoppingCart.GetShoppingCartItems();
            shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartViewModel()
            {
                ShoppingCart = shoppingCart,
                TotalFees = shoppingCart.GetShoppingCartTotalPrice(),
            };
            return View(response);
        }

        public async Task<IActionResult> ReviewOrders()
        {
            string userId = "";
            var allOrders = await orderRepo.GetOrderItemsByUserId(userId);
            return View(allOrders);

        }
        public async Task<IActionResult> AddItemToCart(int id)
        {
            var item = await movieRepo.GetById(id);
            if (item != null)
            {
                shoppingCart.AddItemToCart(item);
            } 
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            var item = await movieRepo.GetById(id);
            if (item != null)
            {
                shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CheckOut()
        {
            var items =  shoppingCart.GetShoppingCartItems();
            string userId = "";
            string UserEmail = "";
            await orderRepo.StoreOrder(items, userId, UserEmail);

            await shoppingCart.ClearShoppingCart();
            return View("CheckOut");
        }
    }
}
