﻿namespace MovieStore.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
