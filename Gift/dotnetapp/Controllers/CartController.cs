// // Controllers/CartController.cs
// using Microsoft.AspNetCore.Mvc;
// using dotnetapp.Models;
// using dotnetapp.Services;
// using System.Text.Json;
// using System.Text.Json.Serialization;


// namespace dotnetapp.Controllers
// {
//     [ApiController]
//     [Route("api/cart")]  
//     public class CartController : ControllerBase
//     {
//         private readonly CartService _cartService;

//     public CartController(CartService cartService)
//     {
//         _cartService = cartService;
//     }

//     // [HttpPost("add")]
//     // public IActionResult addCart([FromBody] Cart cart)
//     // {
//     //     // var addedCart = _cartService.addCart(cart);
//     //     var addedCart = _cartService.addCart(cart);
//     //     return Ok(addedCart);
//     // }

//       [HttpPost("add")]
//         public IActionResult addCart([FromBody] Cart cart)
//         {
//             Console.WriteLine("controller");

//             var addedCart = _cartService.addCart(cart);

//             if (addedCart == null)
//             {
//                 // Handle the case where the operation failed (e.g., customer not found)
//                 return NotFound("Customer not found or other error occurred");
//             }

//             return Ok(addedCart);
//         }

//     [HttpPost("update")]
//     public IActionResult updateCart([FromBody] Cart updatedCart)
//     {
//         var result = _cartService.updateCart(updatedCart);

//         if (result != null)
//         {
//             return Ok(result);
//         }

//         return NotFound("Cart not found");
//     }

//     [HttpGet("customer/{customerId}")]
// public IActionResult getCartByCustomerId(long customerId)
// {
//     var cart = _cartService.getCartByCustomerId(customerId);

//     if (cart != null)
//     {
//         return Ok(cart);
//     }

//     return NotFound("Cart not found");
// }


// // [HttpGet("customer/{customerId}/gifts")]
// // public IActionResult getAllGiftsByCustomerId(long customerId)
// // {
// //     var gifts = _cartService.getAllGiftsByCustomerId(customerId);

// //     if (gifts != null)
// //     {
// //         return Ok(gifts);
// //     }

// //     return NotFound("Gifts not found for the specified customer");
// // }

// [HttpGet("customer/{customerId}/gifts")]
// public IActionResult getAllGiftsByCustomerId(long customerId)
// {
//     var gifts = _cartService.getAllGiftsByCustomerId(customerId);

//     if (gifts != null)
//     {
//         return Ok(gifts);
//     }

//     return NotFound("Gifts not found for the specified customer");
// }



//     }
// }



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
