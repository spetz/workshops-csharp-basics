using Source.Models;

namespace Source.Services
{
    public interface IShoppingService
    {
        User SignIn(string email, string password);
        Cart GetCart(string email);
        Product GetProduct(string name);
    }
}