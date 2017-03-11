using System;
using System.Linq;
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
                Console.WriteLine("Processing an order...");
                User user = _database.Users.GetById(cart.UserId);
                int orderId = _database.Orders.Any() ? _database.Orders.Max(x => x.Id) + 1 : 1;
                Order order = new Order(orderId);
                foreach(CartItem item in cart.Items)
                {
                    Product product = _database.Products.GetById(item.ProductId);
                    order.AddProduct(product, item.Quantity);
                }
                user.PurchaseOrder(order);
                _database.SaveChanges();

                return order;
            }, 
            ex => Console.WriteLine("Ther was an error when processing an order."));
    }
}