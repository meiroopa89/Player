// OrderRepository.cs

using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

public class OrderRepository
{
    private readonly ApplicationDbContext _context;

    public OrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Order AddOrder(Order order)
    {
        _context.Orders.Add(order);
        _context.SaveChanges();
        return order;
    }

    public List<Order> GetAllOrders()
    {
        return _context.Orders.ToList();
    }

    public Order GetOrderById(int orderId)
    {
        return _context.Orders.FirstOrDefault(o => o.OrderId == orderId);
    }

    public Order DeleteOrder(int orderId)
    {
        var orderToDelete = _context.Orders.FirstOrDefault(o => o.OrderId == orderId);

        if (orderToDelete != null)
        {
            _context.Orders.Remove(orderToDelete);
            _context.SaveChanges();
        }

        return orderToDelete;
    }

    public List<Order> GetOrdersByCustomerId(long customerId)
    {
        return _context.Orders.Where(o => o.CustomerId == customerId).ToList();
    }
}
