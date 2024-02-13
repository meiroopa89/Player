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
        private readonly CustomerService _customerService;

    public CartController(CartService cartService, CustomerService customerService)
    {
        _cartService = cartService;
        _customerService = customerService;
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
    if (cart.CustomerId > 0)
    {
        // Fetch customer details based on the provided customerId
        var customer = _customerService.getCustomerById(cart.CustomerId);

        if (customer == null)
        {
            return NotFound("Customer not found");
        }

        // Assign the customer details to the cart
        cart.CustomerId = customer.CustomerId;
        cart.Customer = customer;
    }

    var addedCart = _cartService.addCart(cart);
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
    public IActionResult getCustomerById(long customerId)
    {
        var cart = _cartService.getCustomerById(customerId);

        if (cart != null)
        {
            return Ok(cart);
        }

        return NotFound("Cart not found");
    }

    // [HttpPost("addWithCustomerId/{customerId}")]
    // public IActionResult addCartWithCustomerId(long customerId, [FromBody] Cart cart)
    // {
    //     var addedCart = _cartService.addCartWithCustomerId(customerId, cart);
    //     return Ok(addedCart);
    // }
    }
}
