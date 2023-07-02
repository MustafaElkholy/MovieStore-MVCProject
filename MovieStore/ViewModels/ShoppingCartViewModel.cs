using MovieStore.Data.ShoppingCartData;

namespace MovieStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public CartData ShoppingCart { get; set; }
        public double TotalFees { get; set; }
    }
}
