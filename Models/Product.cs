using System;

namespace Source.Models
{
    public class Product : Entity
    {
        public decimal Price { get; }
        public string Name { get; }

        public Product(int id, string name, decimal price) : base(id)
        {
            if(id <= 0)
            {
                throw new Exception("Product id must be greater than 0.");
            }
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Product name can not be empty.");
            }
            if(price <= 0)
            {
                throw new Exception("Product price must be greater than 0.");
            }
            Name = name;
            Price = price;
        }
    }
}