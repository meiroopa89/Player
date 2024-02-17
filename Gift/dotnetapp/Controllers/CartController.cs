//new
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Services;
using Microsoft.AspNetCore.Authorization;



[Route("api/cart")]
[ApiController]
public class CartController : ControllerBase
{
    private readonly CartService _cartService;
    private readonly GiftService _giftService;

    public CartController(CartService cartService, GiftService giftService)
    {
        _cartService = cartService;
        _giftService = giftService;
    }

    // [HttpPost("add")]
    // public IActionResult AddToCart([FromBody] Cart cart, [FromQuery] int giftId, [FromQuery] int customerId)
    // {
    //     var result = _cartService.AddCart(cart, giftId, customerId);

    //     if (result == null)
    //     {
    //         return NotFound("Customer or Gift not found"); // Or handle accordingly
    //     }

    //     return Ok(result);
    // }

// [HttpPost("addgift")]
// public async Task<IActionResult> AddToCart([FromBody] long giftId)
// {
//     try
//     {
//         // Retrieve the customer ID from the current user's claims
//         long customerId = long.Parse(User.FindFirst("sub")?.Value);

//         // Create a new cart instance (you can modify this if needed)
//         Cart cart = new Cart();

//         // Call the updated AddCart method to add the gift to the cart
//         Cart updatedCart = _cartService.AddCart(cart, giftId, customerId);

//         if (updatedCart == null)
//         {
//             return BadRequest("Failed to add gift to cart");
//         }

//         return Ok(updatedCart); // You might want to return the updated cart or a success message
//     }
//     catch (Exception ex)
//     {
//         return StatusCode(500, $"An error occurred while adding the gift to the cart: {ex.Message}");
//     }
// }




    [Authorize(Roles = "customer")]      
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

    [Authorize(Roles = "customer")]      
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

    [Authorize(Roles = "customer")] 
    [HttpGet("gifts/{customerId}")]
    public IActionResult GetAllGiftsByCustomerId(long customerId)
    {
        var gifts = _cartService.getAllGiftsByCustomerId(customerId);
        return Ok(gifts);
    }

    [Authorize(Roles = "admin,customer")] 
    [HttpGet("customer/{customerId}/total")]
    public IActionResult GetCustomerCartTotalAmount(long customerId)
    {
        double totalAmount = _cartService.CalculateTotalAmount(customerId);

        return Ok(new { TotalAmount = totalAmount });
    }
}
