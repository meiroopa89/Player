// using System.Collections.Generic;
// using dotnetapp.Models;

// namespace dotnetapp.Services
// {
//     public class CartServiceImpl : CartService
//     {
//         private readonly CartRepository _cartRepository;

//         public CartServiceImpl(CartRepository cartRepository)
//         {
//             _cartRepository = cartRepository;
//         }

//         public Cart addCart(Cart cart)
//         {
//             return _cartRepository.addCart(cart);
//         }

//         public Cart updateCart(Cart updatedCart)
//         {
//             return _cartRepository.updateCart(updatedCart);
//         }

//         public Cart getCartByCustomerId(long customerId)
//         {
//             return _cartRepository.getCartByCustomerId(customerId);
//         }
//     }
// }
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Repositories;
using dotnetapp.Services;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;


namespace dotnetapp.Services
{
    public class CartServiceImpl : CartService
    {
        private readonly CartRepository _cartRepository;
        private readonly CustomerService _customerService;
        private readonly ApplicationDbContext _context;

        public CartServiceImpl(CartRepository cartRepository, CustomerService customerService, ApplicationDbContext context)
        {
            _cartRepository = cartRepository;
            _customerService = customerService;
            _context = context;
        }

        public Cart addCart(Cart cart)
        {
            if (cart.CustomerId > 0)
            {
Console.WriteLine(cart);

                // var customer = _customerService.getCustomerById(cart.CustomerId);
                 var customer = _context.Customers
                .Include(c => c.User) // Include any related entities you want to load
                .FirstOrDefault(c => c.CustomerId == cart.CustomerId);
Console.WriteLine(customer);
                if (customer == null)
                {
                    return null;
                }

                cart.CustomerId = customer.CustomerId;
                cart.Customer = customer;
            }

            _cartRepository.addCart(cart);
            return cart;
        }

        public Cart updateCart(Cart updatedCart)
        {
            return _cartRepository.updateCart(updatedCart);
        }

        public Cart getCartByCustomerId(long customerId)
        {
            return _cartRepository.getCartByCustomerId(customerId);
        }

    }
}
