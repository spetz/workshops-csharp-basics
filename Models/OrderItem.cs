namespace Source.Models
{
    public class OrderItem : Item
    {
        public OrderItem(int productId, int quantity) : base(productId, quantity)
        {
        }
    }
}