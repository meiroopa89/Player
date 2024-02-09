// Controllers/CustomerController.cs
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Models;
using dotnetapp.Services;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/customer")]  // Assuming you want the endpoint to be "api/customer"
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public IActionResult RegisterCustomer([FromBody] Customer customer)
        {
            var registeredCustomer = _customerService.RegisterCustomer(customer);

            return CreatedAtAction(nameof(ViewCustomerById), new { id = registeredCustomer.CustomerId }, registeredCustomer);
        }

        [HttpGet("{id}")]
        public IActionResult ViewCustomerById(long id)
        {
            var customer = _customerService.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound(new { Message = "Customer not found." });
            }

            return Ok(customer);
        }
    }
}
