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
    // Iterate through gifts in the order
    foreach (var gift in order.Gifts)
    {
        // Check if the gift already exists in the database
        var existingGift = _context.Gifts.FirstOrDefault(g => g.GiftId == gift.GiftId);
        
        if (existingGift != null)
        {
            // If the gift exists, associate it with the order
            order.Gifts.Remove(gift); // Remove from order
            order.Gifts.Add(existingGift); // Add existing gift
        }
        else
        {
            // If the gift doesn't exist, remove its ID
            gift.GiftId = 0;
        }
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