using System;
using System.Collections.Generic;
using System.Linq;
using Source.Models;
using Source.Persistence;

namespace Source.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly IDatabase _database;
        private IDictionary<string, Cart> _userCarts = new Dictionary<string, Cart>();

        public ShoppingService(IDatabase database)
        {
            _database = database;
        }

        public User SignIn(string email, string password)
        {
            Console.WriteLine($"Signing in user '{email}'...");
            User user = _database.Users.First(x => x.Email == email);
            if(user.Password != password)
            {
                throw new Exception("Invalid credentials");
            }
            _userCarts[user.Email] = new Cart(user);

            return user;
        }

        public Cart GetCart(string email) => _userCarts[email];

        public Product GetProduct(string name) => _database.Products.First(x => x.Name == name);
    }
}