using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;
 
namespace dotnetapp.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext _context;
 
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }
 
        // public Order AddOrder(Order order)
        // {
        //     _context.Orders.Add(order);
        //     _context.SaveChanges();
        //     return order;
        // }

public Order AddOrder(Order order)
{
    // Materialize the order.Gifts collection into a list
    var giftIds = order.Gifts.Select(og => og.GiftId).ToList();

    // Find existing gifts by their IDs
    var existingGifts = _context.Gifts
        .Where(g => giftIds.Contains(g.GiftId))
        .ToList();

    // Clear the original gifts collection in the order
    order.Gifts.Clear();

    // Add existing gifts to the order
    foreach (var existingGift in existingGifts)
    {
        order.Gifts.Add(existingGift);
    }

    // Add the order to the context and save changes
    _context.Orders.Add(order);
    _context.SaveChanges();

    return order;
}


 
        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Gifts)  // Include the associated gifts
                .ToList();
        }
 
        public Order GetOrderById(long orderId)
        {
            return _context.Orders
                .Include(o => o.Gifts)  // Include the associated gifts
                .FirstOrDefault(o => o.OrderId == orderId);
        }
 
        public List<Order> GetOrdersByCustomerId(long customerId)
        {
            return _context.Orders
                .Where(o => o.CustomerId == customerId)
                .Include(o => o.Gifts)  // Include the associated gifts
                .ToList();
        }
    }
}