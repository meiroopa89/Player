// // Controllers/OrderController.cs
// using Microsoft.AspNetCore.Mvc;
// using dotnetapp.Models;
// using dotnetapp.Services;

// namespace dotnetapp.Controllers
// {
//     [ApiController]
//     [Route("api/order")]
//     public class OrderController : ControllerBase
//     {
//         private readonly OrderService _orderService;

//         public OrderController(OrderService orderService)
//         {
//             _orderService = orderService;
//         }

//         [HttpPost]
//         public IActionResult addOrder([FromBody] Orders order)
//         {
//             // Placeholder: Add order logic
//             var addedOrder = _orderService.addOrder(order);

//             return CreatedAtAction(nameof(viewOrderById), new { orderId = addedOrder.OrdersId }, addedOrder);
//         }

//         [HttpDelete("{orderId}")]
//         public IActionResult cancelOrder(long ordersId)
//         {
//             // Placeholder: Cancel order logic
//             var result = _orderService.cancelOrder(ordersId);

//             if (result)
//             {
//                 return Ok(new { Message = "Order cancelled successfully." });
//             }

//             return NotFound(new { Message = "Order not found." });
//         }

//         [HttpGet]
//         public IActionResult viewAllOrders()
//         {
//             // Placeholder: Get all orders logic
//             var orders = _orderService.viewAllOrders();

//             return Ok(orders);
//         }

//         [HttpGet("{orderId}")]
//         public IActionResult viewOrderById(long ordersId)
//         {
//             // Placeholder: Get order by Id logic
//             var order = _orderService.viewOrderById(ordersId);

//             if (order == null)
//             {
//                 return NotFound(new { Message = "Order not found." });
//             }

//             return Ok(order);
//         }

//         [HttpGet("customer/{customerId}")]
//         public IActionResult viewOrderByCustomerId(long customerId)
//         {
//             // Placeholder: Get orders by customer Id logic
//             var orders = _orderService.viewOrderByCustomerId(customerId);

//             return Ok(orders);
//         }
//     }
// }
