// Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;

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

        [HttpPost]
        public IActionResult addCart([FromBody] Cart cart)
        {
            var addedCart = _cartService.addCart(cart);

            return CreatedAtAction(nameof(addCart), new { id = addedCart.CartId }, addedCart);
        }

        [HttpPut("{id}")]
        public IActionResult updateCart(long id, [FromBody] Cart updatedCart)
        {
            var editedCart = _cartService.updateCart(updatedCart);

            if (editedCart != null)
            {
                return Ok(editedCart);
            }

            return NotFound(new { Message = "Cart not found." });
        }

        [HttpGet("customer/{customerId}")]
        public IActionResult getCartByCustomerId(long customerId)
        {
            var cart = _cartService.getCartByCustomerId(customerId);

            if (cart == null)
            {
                return NotFound(new { Message = "Cart not found." });
            }

            return Ok(cart);
        }
    }
}
