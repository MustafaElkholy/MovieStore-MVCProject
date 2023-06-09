﻿using Microsoft.EntityFrameworkCore;
using MovieStore.Data.DataBase;
using MovieStore.Models;
using MovieStore.Repository.Interface;

namespace MovieStore.Repository.Service
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<List<Order>> GetOrderItemsByUserIdAndRole(string userId, string userRole)
        {
            var orders =  await context.Orders.Include(x => x.OrderItems).ThenInclude(x => x.Movie).Include(x=>x.AppUser).ToListAsync();

            if (userRole != "Admin")
            {
                orders = orders.Where(x => x.UserId == userId).ToList();

            }
            return orders;

         
        }

        public async Task StoreOrder(List<ShoppingCart> items, string userId, string userEmail)
        {
            var order = new Order()
            {
                UserId = userId,
                EmailAddress = userEmail
                
            };
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orederItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price

                };

               await context.OrderItems.AddAsync(orederItem);    
            }
            await context.SaveChangesAsync();


        }
    }
}
