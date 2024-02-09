// Controllers/OrderController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult addOrder([FromBody] Order order)
        {
            // Placeholder: Add order logic
            var addedOrder = _orderService.AddOrder(order);

            return CreatedAtAction(nameof(viewOrderById), new { orderId = addedOrder.OrderId }, addedOrder);
        }

        [HttpDelete("{orderId}")]
        public IActionResult cancelOrder(long orderId)
        {
            // Placeholder: Cancel order logic
            var result = _orderService.CancelOrder(orderId);

            if (result)
            {
                return Ok(new { Message = "Order cancelled successfully." });
            }

            return NotFound(new { Message = "Order not found." });
        }

        [HttpGet]
        public IActionResult viewAllOrders()
        {
            // Placeholder: Get all orders logic
            var orders = _orderService.GetAllOrders();

            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public IActionResult viewOrderById(long orderId)
        {
            // Placeholder: Get order by Id logic
            var order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound(new { Message = "Order not found." });
            }

            return Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult viewOrderByCustomerId(long customerId)
        {
            // Placeholder: Get orders by customer Id logic
            var orders = _orderService.GetOrdersByCustomerId(customerId);

            return Ok(orders);
        }
    }
}
