using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Data.ShoppingCartData;
using MovieStore.Models;
using MovieStore.Repository.Interface;
using MovieStore.ViewModels;
using System.Security.Claims;

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
        [Authorize]

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

        [Authorize(Roles ="Admin")]

        public async Task<IActionResult> ReviewOrders()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var allOrders = await orderRepo.GetOrderItemsByUserIdAndRole(userId, userRole);
            return View(allOrders);

        }
        [Authorize]

        public async Task<IActionResult> AddItemToCart(int id)
        {
            var item = await movieRepo.GetById(id);
            if (item != null)
            {
                shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            var item = await movieRepo.GetById(id);
            if (item != null)
            {
                shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction("Index");
        }

        [Authorize]

        public async Task<IActionResult> CheckOut()
        {
            var items = shoppingCart.GetShoppingCartItems();

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
            string UserEmail = User.FindFirstValue(ClaimTypes.Email);

            await orderRepo.StoreOrder(items, userId, UserEmail);

            await shoppingCart.ClearShoppingCart();
            return View("CheckOut");
        }
    }
}
