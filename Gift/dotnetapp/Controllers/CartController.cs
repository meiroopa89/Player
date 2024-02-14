//new
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Services;


[Route("api/[controller]")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;

    public CartController(CartService cartService)
    {
        _cartService = cartService;
    }

    [HttpPost("add")]
    public IActionResult AddCart([FromBody] Cart cart)
    {
        var addedCart = _cartService.addCart(cart);
        if (addedCart != null)
        {
            return Ok(addedCart);
        }
        return BadRequest("Failed to add cart");
    }


    // [HttpPost("add/{giftId}")]
    // public IActionResult AddCart([FromBody] Cart cart, long giftId)
    // {
    //     var addedCart = _cartService.addCart(cart, giftId);

    //     if (addedCart != null)
    //     {
    //         return Ok(addedCart);
    //     }

    //     return BadRequest("Failed to add cart");
    // }


    [HttpPut("update/{cartId}")]
    public IActionResult UpdateCart([FromBody] Cart updatedCart)
    {
        
        var updated = _cartService.updateCart(updatedCart);

        if (updated != null)
        {
            return Ok(updated);
        }
        return BadRequest("Cart not found");
    }

    [HttpGet("get/{customerId}")]
    public IActionResult GetCartByCustomerId(long customerId)
    {
        var cart = _cartService.getCartByCustomerId(customerId);
        if (cart != null)
        {
            return Ok(cart);
        }
        return NotFound($"Cart not found for customer ID: {customerId}");
    }

    [HttpGet("gifts/{customerId}")]
    public IActionResult GetAllGiftsByCustomerId(long customerId)
    {
        var gifts = _cartService.getAllGiftsByCustomerId(customerId);
        return Ok(gifts);
    }
}
