namespace Source.Models
{
    public class CartItem : Item
    {
        public CartItem(int productId, int quantity, decimal unitPrice) 
            : base(productId, quantity, unitPrice)
        {
        }
    }
}