// Repositories/CustomerRepository.cs
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // public Customer registerCustomer(Customer customer)
        // {
        //     Console.Write("sss"+customer.CustomerId);
            
        //     _context.Customers.Add(customer);
        //     _context.SaveChanges();
        //     return customer;
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
            return _context.Customers.Find(customerId);
        }

        // Include method to eagerly load the User navigation property
        public IQueryable<Customer> IncludeUser()
        {
            return _context.Customers.Include(c => c.User);
        }
    }
}
