namespace Source.Models
{
    public class CartItem : Item
    {
        public CartItem(Product product, int quantity = 1) : base(product.Id, quantity)
        {
        }
    }
}