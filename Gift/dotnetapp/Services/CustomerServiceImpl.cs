// Services/CustomerService.cs
using System;
using dotnetapp.Models;
using dotnetapp.Repositories;

namespace dotnetapp.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer registerCustomer(Customer customer)
        {
            // Perform any necessary validation or business logic
            // before calling the repository method.
            
            return _customerRepository.registerCustomer(customer);
        }

        public Customer viewCustomerById(long customerId)
        {
            // Perform any necessary validation or business logic
            // before calling the repository method.

            return _customerRepository.viewCustomerById(customerId);
        }
    }
}
