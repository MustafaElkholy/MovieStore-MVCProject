using Microsoft.EntityFrameworkCore;
using MovieStore.Models;
using System.Linq;

namespace MovieStore.Data.ShoppingCartData
{
    public class CartData
    {
        public AppDbContext Context { get; }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCart> ShoppingCartItems { get; set; }
        public CartData(AppDbContext context)
        {
            Context = context;
        }

        public List<ShoppingCart> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = Context.ShoppingCarts
                .Where(c => c.ShoppingCartId == ShoppingCartId).Include(x=>x.Movie).ToList());
        }

        public double GetShoppingCartTotalPrice()
        {
            var total = Context.ShoppingCarts.Where(c => c.ShoppingCartId == ShoppingCartId).Select(p => p.Movie.Price * p.Amount).Sum();
            return total;
        }

 
        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = Context.ShoppingCarts.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem is null)
            {
                shoppingCartItem = new ShoppingCart()
                {
                    ShoppingCartId = ShoppingCartId,
                    Movie = movie,
                    Amount = 1
                };

                Context.ShoppingCarts.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            Context.SaveChanges();
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = Context.ShoppingCarts.FirstOrDefault(n => n.Movie.Id == movie.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    Context.ShoppingCarts.Remove(shoppingCartItem);

                }
            }
            Context.SaveChanges();


        }

        public static CartData GetShopingCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContext>();

            string cartId = session.GetString("CartId")?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new CartData(context) { ShoppingCartId = cartId };
        }

        public async Task ClearShoppingCart()
        {
            var items = await Context.ShoppingCarts.Where(c => c.ShoppingCartId == ShoppingCartId).ToListAsync();
            Context.ShoppingCarts.RemoveRange(items);
            await Context.SaveChangesAsync();
        }


    }
}
