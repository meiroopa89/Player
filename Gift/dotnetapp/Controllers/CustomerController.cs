// Controllers/CustomerController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult registerCustomer([FromBody] Customer customer)
        {
            var registeredCustomer = _customerService.RegisterCustomer(customer);

            return CreatedAtAction(nameof(registerCustomer), new { id = registeredCustomer.CustomerId }, registeredCustomer);
        }

        [HttpGet("{customerId}")]
        public IActionResult viewCustomerById(long customerId)
        {
            var customer = _customerService.ViewCustomerById(customerId);

            if (customer == null)
            {
                return NotFound(new { Message = "Customer not found." });
            }

            return Ok(customer);
        }
    }
}
