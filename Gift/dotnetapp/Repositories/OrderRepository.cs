// Repositories/OrderRepository.cs
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Data;

namespace dotnetapp.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Order addOrder(Order order)
        {
            // Placeholder: Add order to the database
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public bool cancelOrder(long orderId)
        {
            // Placeholder: Cancel order in the database
            var order = _context.Orders.Find(orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Order> viewAllOrders()
        {
            // Placeholder: Retrieve all orders from the database
            return _context.Orders.ToList();
        }

        public Order viewOrderById(long orderId)
        {
            // Placeholder: Retrieve order by Id from the database
            return _context.Orders.Find(orderId);
        }

        public List<Order> viewOrderByCustomerId(long customerId)
        {
            // Placeholder: Retrieve orders by customer Id from the database
            return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
        }
    }
}
