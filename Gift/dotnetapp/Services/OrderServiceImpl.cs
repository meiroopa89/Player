// // Services/OrderService.cs
// using dotnetapp.Models;
// using dotnetapp.Repositories;
// using System;
// using System.Collections.Generic;

// namespace dotnetapp.Services
// {
//     public class OrderServiceImpl
//     {
//         private readonly OrderRepository _orderRepository;

//         public OrderServiceImpl(OrderRepository orderRepository)
//         {
//             _orderRepository = orderRepository;
//         }

//         public Orders addOrder(Orders order)
//         {
//             // Your implementation here
//             return _orderRepository.addOrder(order);
//         }

//         public bool cancelOrder(long ordersId)
//         {
//             // Your implementation here
//             return _orderRepository.cancelOrder(ordersId);
//         }

//         public List<Orders> viewAllOrders()
//         {
//             // Your implementation here
//             return _orderRepository.viewAllOrders();
//         }

//         public Orders viewOrderById(long ordersId)
//         {
//             // Your implementation here
//             return _orderRepository.viewOrderById(ordersId);
//         }

//         public List<Orders> viewOrderByCustomerId(long customerId)
//         {
//             // Your implementation here
//             return _orderRepository.viewOrderByCustomerId(customerId);
//         }
//     }
// }
