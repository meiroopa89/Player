// OrderController.cs

using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapp.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

         [HttpPost]
    [HttpPost]
        public ActionResult<Order> AddOrder([FromBody] Order order)
        {
            var result = _orderService.AddOrder(order);

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Failed to add order.");
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public ActionResult<Order> GetOrderById(long orderId)
        {
            var order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }

            return Ok(order);
        }

        [HttpDelete("{orderId}")]
        public ActionResult<Order> DeleteOrder(long orderId)
        {
            var deletedOrder = _orderService.DeleteOrder(orderId);

            if (deletedOrder == null)
            {
                return NotFound(new { message = "Order not found" });
            }

            return Ok(deletedOrder);
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<List<Order>> GetOrdersByCustomerId(long customerId)
        {
            var orders = _orderService.GetOrdersByCustomerId(customerId);
            return Ok(orders);
        }
    }
}
