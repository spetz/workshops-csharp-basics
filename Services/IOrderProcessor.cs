using Source.Models;

namespace Source.Services
{
    public interface IOrderProcessor
    {
        Result<Order> CompleteOrder(Cart cart);
    }
}