using System.Collections.Generic;
using Source.Models;

namespace Source.Persistence
{
    public interface IDatabase
    {
        void Connect();
        void Disconnect();
        void SaveChanges();
        ICollection<Order> Orders { get; }
        ICollection<Product> Products { get; }
        ICollection<User> Users { get; }
    }
}