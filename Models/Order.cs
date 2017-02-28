using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class Order : Entity
    {
        private readonly ISet<OrderItem> _items = new HashSet<OrderItem>();
        public decimal Price { get; private set; }
        public decimal TaxRate { get; } = 0.23M;
        public decimal TotalPrice => (1 + TaxRate) * Price;
        public bool IsPurchased { get; private set; }
        public IEnumerable<OrderItem> Items => _items;

        public Order(int id) : base(id)
        {
        }

        public void AddProduct(Product product, int quantity)
        {
            _items.Add(new OrderItem(product.Id, quantity));
            Price += product.Price * quantity;
        }

        public void RemoveProduct(int productId)
        {
            OrderItem existingItem = null;
            foreach(OrderItem item in Items)
            {
                if(item.ProductId == productId)
                {
                    existingItem = item;
                    break;
                }
            }
            if(existingItem == null)
            {
                throw new Exception($"Product with id {productId} was not found.");
            }
            _items.Remove(existingItem);
        }

        public void Purchase()
        {
            if(IsPurchased)
            {
                throw new Exception("Order was already purchased.");
            }
            IsPurchased = true;
        }
    }
}