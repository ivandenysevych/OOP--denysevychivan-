using System;
using System.Collections.Generic;
using lab20.Models;
using lab20.Interfaces;

namespace lab20.Services
{
    public class InMemoryOrderRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> _orders = new();

        public void Save(Order order)
        {
            _orders[order.Id] = order;
            Console.WriteLine($"[Repository] Замовлення #{order.Id} збережено.");
        }

        public Order GetById(int id)
        {
            _orders.TryGetValue(id, out var order);
            return order;
        }
    }
}
