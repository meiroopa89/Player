using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Services;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;
using dotnetapp.Data;

 
namespace dotnetapp.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // private readonly IOrderService _orderService;
        // private readonly CartService _cartService; // Change here

        // public OrderController(IOrderService orderService, CartService cartService) // Change here
        // {
        //     _orderService = orderService;
        //     _cartService = cartService;
        // }

        private readonly ApplicationDbContext _context;
        private readonly IOrderService _orderService;
        private readonly CartService _cartService;

        public OrderController(ApplicationDbContext context, IOrderService orderService, CartService cartService)
        {
            _context = context;
            _orderService = orderService;
            _cartService = cartService;
        }

 
    // [Authorize]
    [HttpPost]
        // public ActionResult<Order> AddOrder([FromBody] Order order)
        // {
        //     var result = _orderService.AddOrder(order);
 
        //     if (result != null)
        //     {
        //         return Ok(result);
        //     }
 
        //     return BadRequest("Failed to add order.");
        // }

public ActionResult<Order> AddOrder([FromBody] Order order)
{
    var addedOrder = _orderService.AddOrder(order);

    if (addedOrder != null)
    {
        foreach (var gift in order.Gifts)
        {
            var existingGift = _context.Gifts.FirstOrDefault(g => g.GiftId == gift.GiftId);
            if (existingGift != null)
            {
                // Assuming CartId is set appropriately
                existingGift.CartId = gift.CartId;

                // Retrieve the corresponding cart
                var cart = _context.Carts.FirstOrDefault(c => c.CartId == gift.CartId);
                if (cart != null)
                {
                    // Add the gift to the cart
                    cart.Gifts.Add(existingGift);
                }
                else
                {
                    // If the cart doesn't exist, you may need to create a new one
                    // Handle this scenario based on your application logic
                }
            }
            else
            {
                // Handle case where gift does not exist
                // It's up to your application logic how to handle this scenario
            }
        }

        // Save changes to persist the updates to the database
        _context.SaveChanges(); 

        // Assuming your OrderService method returns the added order
        var result = _orderService.AddOrder(order);

        if (result != null)
        {
            return Ok(result);
        }
    }

    return BadRequest("Failed to add order.");
}



 
        // [Authorize]
        [HttpGet]
        public ActionResult<List<Order>> GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }
 
        // [Authorize]
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
 
        // [Authorize(Roles = "customer")]
        // [HttpDelete("{orderId}")]
        // public ActionResult<Order> DeleteOrder(long orderId)
        // {
        //     var deletedOrder = _orderService.DeleteOrder(orderId);
 
        //     if (deletedOrder == null)
        //     {
        //         return NotFound(new { message = "Order not found" });
        //     }
 
        //     return Ok(deletedOrder);
        // }
 
        // [Authorize]
        [HttpGet("customer/{customerId}")]
        public ActionResult<List<Order>> GetOrdersByCustomerId(long customerId)
        {
            var orders = _orderService.GetOrdersByCustomerId(customerId);
            return Ok(orders);
        }
    }
}