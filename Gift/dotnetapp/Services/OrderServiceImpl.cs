// OrderServiceImpl.cs

using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Repositories;

namespace dotnetapp.Services
{
    public class OrderServiceImpl : IOrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderServiceImpl(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

       public Order AddOrder(Order order, int giftId)
        {
            // Retrieve the gift by giftId
            var giftToAdd = _orderRepository.GetGiftById(giftId);

            if (giftToAdd != null)
            {
                // Associate the gift with the order
                order.Gifts = new List<Gift> { giftToAdd };
                return _orderRepository.AddOrder(order);
            }

            // Handle case where the gift is not found
            return null;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public Order GetOrderById(long orderId)
        {
            return _orderRepository.GetOrderById(orderId);
        }

        public Order DeleteOrder(long orderId)
        {
            return _orderRepository.DeleteOrder(orderId);
        }

        public List<Order> GetOrdersByCustomerId(long customerId)
        {
            return _orderRepository.GetOrdersByCustomerId(customerId);
        }
    }
}
