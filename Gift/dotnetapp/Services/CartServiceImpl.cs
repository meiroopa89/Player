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

namespace dotnetapp.Services
{
    public class CartServiceImpl : CartService
    {
        private readonly CartRepository _cartRepository;
        //  private readonly CustomerService _customerService;
         private readonly ApplicationDbContext _context;

    public CartServiceImpl(CartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Cart addCart(Cart cart)
    {
        return _cartRepository.addCart(cart);
    }

    public Cart updateCart(Cart updatedCart)
    {
        return _cartRepository.updateCart(updatedCart);
    }

    public Cart customer(long customerId)
    {
        return _cartRepository.customer(customerId);
    }

//     public Cart addCartWithCustomerId(long customerId, Cart cart)
// {
//     // Fetch customer details based on the provided customerId
//     var customer = _context.Customers.Find(customerId);

//     if (customer == null)
//     {
//         return null; // or handle accordingly, e.g., return NotFound("Customer not found");
//     }

//     // Assign the customer details to the cart
//     cart.CustomerId = customer.CustomerId;
//     cart.Customer = customer;

//     // Save the new cart to the database
//     _context.Carts.Add(cart);
//     _context.SaveChanges();

//     return cart;
// }


    }
}