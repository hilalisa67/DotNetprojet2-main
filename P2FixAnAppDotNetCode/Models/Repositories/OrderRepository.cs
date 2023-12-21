using System.Collections.Generic;

namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();
        public void Save(Order order)
        {
            _orders.Add(order);
        }
    }
}