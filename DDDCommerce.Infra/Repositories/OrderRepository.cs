using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDDCommerce.Domain.Store.Entities;
using DDDCommerce.Domain.Store.Repositories;
using DDDCommerce.Infra.Contexts;

namespace DDDCommerce.Infra.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DDDCommerce_StoreDataContext _context;

        public OrderRepository(DDDCommerce_StoreDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(Guid orderId)
        {
            var order = _context.Orders.FirstOrDefault(c => c.Id == orderId);

            return order;
        }

        public IEnumerable<Order> GetOrdersByCustomer(Guid id)
        {
            var orders = _context.Orders.Include("Customer").ToList().Where(c => c.Customer.Id == id);
            return orders;
        }
    }
}
