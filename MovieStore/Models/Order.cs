﻿namespace MovieStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; } 
        public string UserId { get; set; }

        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
