using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Services
{
    public class CartServiceImpl : CartService
    {
        private readonly CartRepository _cartRepository;
        private readonly ApplicationDbContext _context;
        private readonly CustomerService _customerService;

        public CartServiceImpl(CartRepository cartRepository, ApplicationDbContext context, CustomerService customerService)
        {
            _cartRepository = cartRepository;
            _context = context;
            _customerService = customerService;
        }

        public Cart addCart(Cart cart)
        {
            return _cartRepository.addCart(cart);
        }

        public Cart updateCart(Cart updatedCart)
        {
            return _cartRepository.updateCart(updatedCart);
        }

        // public Cart getCartByCustomerId(long customerId)
        // {
        //     return _cartRepository.getCartByCustomerId(customerId);
        // }

         public Cart getCartByCustomerId(long customerId)
        {
            return _context.Carts
                .Include(cart => cart.Gifts)  // Include the associated gifts
                .FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}

// using System.Collections.Generic;
// using dotnetapp.Models;
// using dotnetapp.Repositories;
// using dotnetapp.Services;
// using dotnetapp.Data;
// using Microsoft.EntityFrameworkCore;


// namespace dotnetapp.Services
// {
//     public class CartServiceImpl : CartService
//     {
//         private readonly CartRepository _cartRepository;
//         private readonly CustomerService _customerService;
//         private readonly ApplicationDbContext _context;

//         public CartServiceImpl(CartRepository cartRepository, CustomerService customerService, ApplicationDbContext context)
//         {
//             _cartRepository = cartRepository;
//             _customerService = customerService;
//             _context = context;
//         }

//         public Cart addCart(Cart cart)
//         {
//             if (cart.CustomerId > 0)
//             {
//                 // var customer = _customerService.getCustomerById(cart.CustomerId);
//                  var customer = _context.Customers
//                 .Include(c => c.User) // Include any related entities you want to load
//                 .FirstOrDefault(c => c.CustomerId == cart.CustomerId);
// Console.WriteLine(customer);
//                 if (customer == null)
//                 {
//                     return null;
//                 }

//                 cart.CustomerId = customer.CustomerId;
//                 cart.Customer = customer;
//             }

//             _cartRepository.addCart(cart);
//             return cart;
//         }

//         public Cart updateCart(Cart updatedCart)
//         {
//             return _cartRepository.updateCart(updatedCart);
//         }

//         public Cart getCartByCustomerId(long customerId)
//         {
//             return _cartRepository.getCartByCustomerId(customerId);
//         }

//         public List<Gift> viewAllGifts(long cartId)
//     {
//         // Implement logic to fetch all gifts associated with the specified cartId
//         var cart = _cartRepository.getGiftById(cartId);
        
//         if (cart != null)
//         {
//             return cart.Gifts.ToList();
//         }

//         return null;
//     }
//      public Gift getGiftById(long cartId, long giftId)
//     {
//         // Implement logic to fetch a gift based on both cartId and giftId
//         var cart = _cartRepository.getGiftById(cartId);

//         if (cart != null)
//         {
//             return cart.Gifts.FirstOrDefault(g => g.GiftId == giftId);
//         }

//         return null;
//     }

//     }
// }
