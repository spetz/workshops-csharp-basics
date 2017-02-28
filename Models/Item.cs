using System;

namespace Source.Models
{
    public abstract class Item
    {
        public int ProductId { get; }
        public int Quantity { get; protected set; }

        protected Item(int productId, int quantity)
        {
            if(productId <= 0)
            {
                throw new Exception("Product id must be greater than 0.");
            }
            if(quantity <= 0)
            {
                throw new Exception("Quantity must be greater than 0.");
            }
            ProductId = productId;
            Quantity = quantity;
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