// Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/cart")]  
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    // [HttpPost("add")]
    // public IActionResult addCart([FromBody] Cart cart)
    // {
    //     // var addedCart = _cartService.addCart(cart);
    //     var addedCart = _cartService.addCart(cart);
    //     return Ok(addedCart);
    // }

    [HttpPost("add")]
        public IActionResult addCart([FromBody] Cart cart)
        {
            Console.WriteLine("controller");

            var addedCart = _cartService.addCart(cart);

            if (addedCart == null)
            {
                // Handle the case where the operation failed (e.g., customer not found)
                return NotFound("Customer not found or other error occurred");
            }

            return Ok(addedCart);
        }

    [HttpPost("update")]
    public IActionResult updateCart([FromBody] Cart updatedCart)
    {
        var result = _cartService.updateCart(updatedCart);

        if (result != null)
        {
            return Ok(result);
        }

        return NotFound("Cart not found");
    }

    [HttpGet("customer/{customerId}")]
    public IActionResult getCartByCustomerId(long customerId)
    {
        var cart = _cartService.getCartByCustomerId(customerId);

        if (cart != null)
        {
            return Ok(cart);
        }

        return NotFound("Cart not found");
    }
    }
}
