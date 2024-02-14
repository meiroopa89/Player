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

public class CartServiceImpl : CartService
{
    private readonly CartRepository _cartRepository;

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

    public Cart getCartByCustomerId(long customerId)
    {
        return _cartRepository.getCartByCustomerId(customerId);
    }

    public List<Gift> getAllGiftsByCustomerId(long customerId)
    {
        return _cartRepository.getAllGiftsByCustomerId(customerId);
    }
}
