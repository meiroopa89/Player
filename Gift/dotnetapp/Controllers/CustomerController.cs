// Controllers/CustomerController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;
using dotnetapp.Services;
using dotnetapp.Data;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService, ApplicationDbContext _context)
        {
            _customerService = customerService;
            _context = _context;
        }

        [HttpPost("registerCustomer")]
public IActionResult RegisterCustomer([FromBody] Customer customer)
{
    if (customer == null)
    {
        return BadRequest("Invalid customer data");
    }

    var registeredCustomer = _customerService.registerCustomer(customer);
    Console.WriteLine("Customer Id: " + registeredCustomer.CustomerId);

    // Assuming 'cart' is defined and initialized somewhere in your code
    Cart cart = new Cart
    {
        // Populate properties of 'cart' here if needed
    };

    // Retrieve the customer from the context based on cart.CustomerId
    var customerFromContext = _context.Customers
        .Include(c => c.User)
        .FirstOrDefault(c => c.CustomerId == cart.CustomerId);

    if (customerFromContext == null)
    {
        return BadRequest("Customer not found");
    }

    // Assign customer details to the cart
    cart.CustomerId = customerFromContext.CustomerId;
    cart.Customer = customerFromContext;

    _context.Carts.Add(cart);
    _context.SaveChanges();

    // Create a new Cart for the customer
    Cart newCart = new Cart
    {
        CustomerId = customerFromContext.CustomerId,
        Gifts = new List<Gift>(), // Assuming Gifts is initialized as an empty list
        TotalAmount = 0.0
    };

    Console.WriteLine("New Cart Id: " + newCart.CartId);

    _context.Carts.Add(newCart);
    _context.SaveChanges();

    return CreatedAtAction(nameof(RegisterCustomer), new { id = registeredCustomer.CustomerId }, registeredCustomer);
}


        // [HttpPost]
        // public IActionResult registerCustomer([FromBody] Customer customer)
        // {
        //     var registeredCustomer = _customerService.registerCustomer(customer);
        //     Console.WriteLine("cusid"+registeredCustomer.CustomerId);
        //     // Cart newCart = new Cart
        //     // {
        //     //     CustomerId = customer.CustomerId,
        //     //     Gifts = new List<Gift>(), // Assuming Gifts is initialized as an empty list
        //     //     TotalAmount = 0.0
        //     // };

        //     // _context.Carts.Add(newCart);
        //     // _context.SaveChanges();

        //     return CreatedAtAction(nameof(registerCustomer), new { id = registeredCustomer.CustomerId }, registeredCustomer);
        // }

        [HttpGet("{customerId}")]
        public IActionResult viewCustomerById(long customerId)
        {
            var customer = _customerService.viewCustomerById(customerId);

            if (customer == null)
            {
                return NotFound(new { Message = "Customer not found." });
            }

            return Ok(customer);
        }
        
    }
}
