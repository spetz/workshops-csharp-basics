using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Source.Models;

namespace Source.Persistence
{
    public class InMemoryDatabase : IDatabase
    {
        private bool _isConnected = false;
        public ICollection<Order> Orders { get; } = new Collection<Order>();
        public ICollection<Product> Products { get; } = new Collection<Product>();
        public ICollection<User> Users { get; } = new Collection<User>();

        public void Connect()
        {
            if(_isConnected)
            {
                return;
            }
            _isConnected = true;
            Console.WriteLine("Connected to the database.");
        }

        public void Disconnect()
        {
            FailIfNotConnected();
            Console.WriteLine("Disconnected from the database.");
        }

        public void SaveChanges()
        {
            FailIfNotConnected();
            Console.WriteLine("Saved changes in a database.");
        }

        private void FailIfNotConnected()
        {
            if(_isConnected)
            {
                return;
            }
            throw new Exception("Can not execute the command on a database without an active connection.");
        }
    }
}