using System;

namespace Source.Models
{
    public abstract class Item
    {
        public int ProductId { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; protected set; }
        public decimal TotalPrice => Quantity * UnitPrice;

        protected Item(int productId, int quantity, decimal unitPrice)
        {
            if(productId <= 0)
            {
                throw new Exception("Product id must be greater than 0.");
            }
            if(quantity <= 0)
            {
                throw new Exception("Quantity must be greater than 0.");
            }
            if(unitPrice < 0)
            {
                throw new Exception("Unit price must can not be less than 0.");
            }            
            ProductId = productId;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }


        public virtual void IncreaseQuantity()
        {
            Quantity++;
        }

        public virtual void DecreaseQuantity()
        {
            if(Quantity == 0)
            {
                return;
            }
            Quantity--;
        }
    }
}