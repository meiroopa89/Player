// using System;
// using dotnetapp.Models;
// using dotnetapp.Repositories;
// using Microsoft.EntityFrameworkCore;
// using dotnetapp.Data;

// namespace dotnetapp.Services
// {
//     public class CustomerServiceImpl : CustomerService
//     {
//         private readonly CustomerRepository _customerRepository;
//         private readonly ApplicationDbContext _context;

//         public CustomerServiceImpl(CustomerRepository customerRepository, ApplicationDbContext context)
//         {
//             _customerRepository = customerRepository;
//             _context = context;
//         }

//         public Customer registerCustomer(Customer customer)
//         {
//             // Perform any necessary validation or business logic
//             // before calling the repository method.
            
//             return _customerRepository.registerCustomer(customer);
//         }

//         public Customer viewCustomerById(long customerId)
//         {
//             // Perform any necessary validation or business logic
//             // before calling the repository method.

//             var customer = _customerRepository.IncludeUser()
//                                               .FirstOrDefault(c => c.CustomerId == customerId);

//             return customer;
//         }

//          public Customer getCustomerById(long customerId)
//         {
//             // Implement the logic to retrieve a customer by ID
//             return _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
//         }
    
//     }
// }


//new
using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;
using dotnetapp.Data;

public class CartServiceImpl : ICartService
{
    private readonly CartRepository _cartRepository;

    public CartServiceImpl(ApplicationDbContext context)
    {
        _cartRepository = new CartRepository(context);
    }

    public Cart addCart(Cart cart)
    {
        return _cartRepository.addCart(cart);
    }

    public Cart updateCart(Cart updatedCart)
    {
        return _cartRepository.updateCart(updatedCart);
    }

    public Cart getCartByCustomerId(long customerId)
    {
        return _cartRepository.getCartByCustomerId(customerId);
    }

    public List<Gift> getAllGiftsByCustomerId(long customerId)
    {
        return _cartRepository.getAllGiftsByCustomerId(customerId);
    }
}
