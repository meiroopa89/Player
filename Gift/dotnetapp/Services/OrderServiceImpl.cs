// Services/OrderService.cs
using dotnetapp.Models;
using dotnetapp.Repositories;
using System;
using System.Collections.Generic;

namespace dotnetapp.Services
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order addOrder(Order order)
        {
            // Your implementation here
            return _orderRepository.addOrder(order);
        }

        public bool cancelOrder(long orderId)
        {
            // Your implementation here
            return _orderRepository.cancelOrder(orderId);
        }

        public List<Order> viewAllOrders()
        {
            // Your implementation here
            return _orderRepository.viewAllOrders();
        }

        public Order viewOrderById(long orderId)
        {
            // Your implementation here
            return _orderRepository.viewOrderById(orderId);
        }

        public List<Order> viewOrderByCustomerId(long customerId)
        {
            // Your implementation here
            return _orderRepository.viewOrderByCustomerId(customerId);
        }
    }
}
