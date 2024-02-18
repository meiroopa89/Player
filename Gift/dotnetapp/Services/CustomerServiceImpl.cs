// Services/CustomerServiceImpl.cs
using System;
using dotnetapp.Models;
using dotnetapp.Repositories;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Data;

namespace dotnetapp.Services
{
    public class CustomerServiceImpl : CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly ApplicationDbContext _context;

        public CustomerServiceImpl(CustomerRepository customerRepository, ApplicationDbContext context)
        {
            _customerRepository = customerRepository;
            _context = context;
        }

        // public Customer registerCustomer(Customer customer)
        // {
        //     // Perform any necessary validation or business logic
        //     // before calling the repository method.
            
        //     return _customerRepository.registerCustomer(customer);
        // }

        public Customer RegisterCustomer(Customer customer, long userId)
{
    // Check if the provided UserId exists in the system
    var existingUser = _context.Users.Find(customer.UserId);

    if (existingUser != null)
    {
        // Associate the existing user with the new customer
        customer.User = existingUser;

        // Add the customer to the context and save changes
        _context.Customers.Add(customer);
        _context.SaveChanges();

        return customer;
    }

    // Handle the case where the provided UserId doesn't exist
    // You might want to throw an exception, return null, or handle it based on your application's logic
    return null;
}


        public Customer viewCustomerById(long customerId)
        {
            // Perform any necessary validation or business logic
            // before calling the repository method.

            var customer = _customerRepository.IncludeUser()
                                              .FirstOrDefault(c => c.CustomerId == customerId);

            return customer;
        }

         public Customer getCustomerById(long customerId)
        {
            // Implement the logic to retrieve a customer by ID
            return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
        }
    
    }
}
