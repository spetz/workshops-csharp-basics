namespace Source.Models
{
    public class OrderItem : Item
    {
        public OrderItem(int productId, int quantity, decimal unitPrice) 
            : base(productId, quantity, unitPrice)
        {
        }
    }
}