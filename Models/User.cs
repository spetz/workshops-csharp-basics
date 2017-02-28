using System;
using System.Collections.Generic;

namespace Source.Models
{
    public class User : Entity
    {
        private readonly ISet<Order> _orders = new HashSet<Order>();
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string FullName { get; set; }
        public int Age { get; protected set; }
        public bool IsActive { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public decimal Funds { get; private set; }
        public IEnumerable<Order> Order =>_orders;

        public User(int id, string email, string password) : base(id)
        {
            SetEmail(email);
            SetPassword(password);
            Activate();
        }

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is incorrect.");
            }
            if(Email == email)
            {
                return;
            }

            Email = email;
            MarkAsUpdated();
        }

        public void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password is incorrect.");
            }
            if(Password == password)
            {
                return;
            }

            Password = password;
            MarkAsUpdated();
        }

        public void SetAge(int age)
        {
            if(age < 13)
            {
                throw new Exception("Age must be greater or equal to 13");
            }
            if(Age == age)
            {
                return;
            }
            
            Age = age;
            MarkAsUpdated();
        }

        public void Activate()
        {
            if(IsActive)
            {
                return;
            }

            IsActive = true;
            MarkAsUpdated();
        }

        public void Deactivate()
        {
            if(!IsActive)
            {
                return;
            }

            IsActive = false;
            MarkAsUpdated();
        }

        public void IncreaseFunds(decimal funds)
        {
            if(funds <= 0)
            {
                throw new Exception("Funds must be greater than 0.");
            }

            Funds += funds;
            MarkAsUpdated();
        }

        public void PurchaseOrder(Order order)
        {
            if(!IsActive)
            {
                throw new Exception("Only active user can purchase an order.");
            }

            decimal orderPrice = order.TotalPrice;
            if(Funds - orderPrice < 0)
            {
                throw new Exception("You don't have enough money.");
            }
            order.Purchase();
            Funds -= orderPrice;
            _orders.Add(order);
            MarkAsUpdated();
        }

        private void MarkAsUpdated()
        {
            UpdatedAt = DateTime.UtcNow;
        }
    }
}