// using System.Collections.Generic;
// using dotnetapp.Models;
// using dotnetapp.Data;
// using Microsoft.EntityFrameworkCore;
// using dotnetapp.Services;

// namespace dotnetapp.Services
// {
//     public class CartServiceImpl : CartService
//     {
//         private readonly CartRepository _cartRepository;
//         private readonly ApplicationDbContext _context;
//         private readonly CustomerService _customerService;

//         public CartServiceImpl(CartRepository cartRepository, ApplicationDbContext context, CustomerService customerService)
//         {
//             _cartRepository = cartRepository;
//             _context = context;
//             _customerService = customerService;
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

//    public List<Gift> getAllGiftsByCustomerId(long customerId)
//     {
//         return _cartRepository.getAllGiftsByCustomerId(customerId);
//     }
//     }
// }



//new
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Services;
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Services;
using dotnetapp.Data;
using dotnetapp.Repositories;
using Microsoft.EntityFrameworkCore;


public class CartServiceImpl : CartService
{
    private readonly CartRepository _cartRepository;
    private readonly ApplicationDbContext _context;

    public CartServiceImpl(CartRepository cartRepository, ApplicationDbContext context)
    {
        _cartRepository = cartRepository;
        _context = context;
    }


    // public Cart addCart(Cart cart)
    // {
    //     return _cartRepository.addCart(cart);
    // }

    // public override Cart addCart(Cart cart, long giftId)
    // {
    //     // Your implementation of addCart, make sure to call the base method if needed
    //     // ...

    //     // Associate the cart with a specific gift using the provided giftId
    //     var gift = _context.Gifts.Find(giftId);

    //     if (gift != null)
    //     {
    //         cart.Gifts = new List<Gift> { gift };
    //     }

    //     // Add the cart to the repository
    //     return _cartRepository.addCart(cart);
    // }

    public Cart AddCart(Cart cart, int giftId, int customerId)
    {
        if (customerId > 0)
        {
            var customer = _context.Customers
                .Include(c => c.User)
                .FirstOrDefault(c => c.CustomerId == customerId);

            if (customer == null)
            {
                return null; // Or handle the situation where the customer is not found
            }

            cart.CustomerId = customer.CustomerId;
            cart.Customer = customer;
        }

        var gift = _context.Gifts.FirstOrDefault(g => g.GiftId == giftId);

        if (gift == null)
        {
            return null; // Or handle the situation where the gift is not found
        }

        // Assuming you have a navigation property in your Cart model to represent the gifts in the cart
        cart.Gifts.Add(gift);

        _context.Carts.Add(cart);
        _context.SaveChanges();

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

    public List<Gift> getAllGiftsByCustomerId(long customerId)
    {
        return _cartRepository.getAllGiftsByCustomerId(customerId);
    }
}
