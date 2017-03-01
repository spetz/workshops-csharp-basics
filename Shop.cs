using System;
using Source.Models;
using Source.Persistence;
using Source.Services;

namespace Source
{
    public class Shop
    {
        public void BuyStuff()
        {
            IDatabase database = CreateDatabase();
            IActionHandler actionHandler = new ActionHandler();
            IShoppingService shoppingService = new ShoppingService(database);
            IOrderProcessor orderProcessor = new OrderProcessor(database, actionHandler);
            
            User user = shoppingService.SignIn("user1@email.com", "secret");
            Cart cart = shoppingService.GetCart("user1@email.com");

            Product ball = shoppingService.GetProduct("Ball");
            cart.AddProduct(ball);
            cart.AddProduct(ball);
            cart.AddProduct(shoppingService.GetProduct("Monitor"));

            Result<Order> completedOrder = orderProcessor.CompleteOrder(cart);
            if(completedOrder.IsSuccessful)
            {
                Console.WriteLine($"Order was completed. You've spent {completedOrder.Value.TotalPrice} PLN.");
                return;
            }
            Console.WriteLine($"There was an error while completing an order.\n" +
                              $"{completedOrder.ErrorMessage}");
        }

        private IDatabase CreateDatabase()
        {
            IDatabase database = new InMemoryDatabase();
            database.Connect();
            Console.WriteLine("Creating a database...");
            User user = new User(1, "user1@email.com", "secret");
            user.IncreaseFunds(1000);
            database.Users.Add(user);
            database.Products.Add(new Product(1, "Ball", 50));
            database.Products.Add(new Product(2, "Hammer", 200));
            database.Products.Add(new Product(3, "Notebook", 3000));
            database.Products.Add(new Product(4, "Monitor", 550));
            database.Products.Add(new Product(5, "Bike", 700));

            return database;
        }
    }
}