using System;
using Source.Models;
using Source.Persistence;

namespace Source.Services
{
    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDatabase _database;
        private readonly IActionHandler _actionHandler;

        public OrderProcessor(IDatabase database, IActionHandler actionHandler)
        {
            _database = database;
            _actionHandler = actionHandler;
        }

        public Result<Order> CompleteOrder(Cart cart)
            => _actionHandler.Handle<Order>(() => 
            {
                Console.WriteLine("Processing order...");
                User user = _database.Users.GetById(cart.UserId);
                Order order = new Order(1);
                foreach(CartItem item in cart.Items)
                {
                    Product product = _database.Products.GetById(item.ProductId);
                    order.AddProduct(product, item.Quantity);
                }
                user.PurchaseOrder(order);
                _database.SaveChanges();

                return order;
            }, ex => Console.WriteLine("Error when processing order."));
    }
}