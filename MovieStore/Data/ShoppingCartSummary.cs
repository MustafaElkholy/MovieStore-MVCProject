using Microsoft.AspNetCore.Mvc;
using MovieStore.Data.ShoppingCartData;

namespace MovieStore.Data
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly CartData shoppingCart;

        public ShoppingCartSummary(CartData shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
