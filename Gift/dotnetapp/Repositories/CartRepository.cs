// using System.Linq;
// using dotnetapp.Data;
// using dotnetapp.Models;

// public class CartRepository
// {
//     private readonly ApplicationDbContext _context;

//     public CartRepository(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     public Cart addCart(Cart cart)
//     {
//         _context.Carts.Add(cart);
//         _context.SaveChanges();
//         return cart;
//     }

//     public Cart updateCart(Cart updatedCart)
//     {
//         var existingCart = _context.Carts.Find(updatedCart.CartId);

//         if (existingCart != null)
//         {
//             // Update properties of existing cart
//             existingCart.Gifts = updatedCart.Gifts;
//             existingCart.CustomerId = updatedCart.CustomerId;
//             // Add any other properties to update

//             _context.SaveChanges();

//             return existingCart;
//         }

//         return null; // Cart not found
//     }

//     public Cart getCartByCustomerId(long customerId)
//     {
//         return _context.Carts.FirstOrDefault(c => c.CustomerId == customerId);
//     }
// }

// using System.Linq;
// using dotnetapp.Data;
// using dotnetapp.Models;
// using Microsoft.EntityFrameworkCore;
// public class CartRepository
// {
// private readonly ApplicationDbContext _context;

//     public CartRepository(ApplicationDbContext context)
//     {
//         _context = context;
//     }

//     // public Cart addCart(Cart cart)
//     // {
//     //     _context.Carts.Add(cart);
//     //     _context.SaveChanges();
//     //     return cart;
//     // }

//     public Cart addCart(Cart cart)
// {
//     if (cart.CustomerId > 0)
//     {
//         Console.WriteLine(cart);

//         // Fetch customer details based on the provided customerId
//         // var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == cart.CustomerId);
//         var customer = _context.Customers
//             .Include(c => c.User) // Include any related entities you want to load
//             .FirstOrDefault(c => c.CustomerId == cart.CustomerId);

//         if (customer == null)
//         {
//             // Handle the case where customer is not found
//             // You might want to return an error response or throw an exception
//             // For now, returning null as an indication that the operation failed
//             return null;
//         }

//         // Assign the customer details to the cart
//         cart.CustomerId = customer.CustomerId;
//         cart.Customer = customer;
//     }

//     _context.Carts.Add(cart);
//     _context.SaveChanges();
//     return cart;
// }

//     public Cart updateCart(Cart updatedCart)
//     {
//         var existingCart = _context.Carts.Find(updatedCart.CartId);

//         if (existingCart != null)
//         {
//             existingCart.Gifts = updatedCart.Gifts;
//             existingCart.CustomerId = updatedCart.CustomerId;

//             _context.SaveChanges();

//             return existingCart;
//         }

//         return null;
//     }

//     public Cart getCartByCustomerId(long customerId)
//     {
//         return _context.Carts.FirstOrDefault(c => c.CustomerId == customerId);
//     }

// //     public Cart getCartByCustomerId(long customerId)
// // {
// //     return _context.Carts
// //         .Include(cart => cart.Gifts)  // Include the associated gifts
// //         .FirstOrDefault(c => c.CustomerId == customerId);
// // }


// public List<Gift> getAllGiftsByCustomerId(long customerId)
// {
//     var cart = getCartByCustomerId(customerId);

//     if (cart != null)
//     {
//         if (cart.Gifts != null)
//         {
//             return cart.Gifts.ToList();
//         }
//         else
//         {
//             Console.WriteLine("Cart has no associated gifts.");
//         }
//     }
//     else
//     {
//         Console.WriteLine($"Cart not found for customer ID: {customerId}");
//     }

//     return new List<Gift>(); // Return an empty list if there are no gifts or the cart is null
// }


// }




//new
using System;
using System.Collections.Generic;
using System.Linq;
using dotnetapp.Data;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

public class CartRepository
{
    private readonly ApplicationDbContext _context;

    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Cart addCart(Cart cart)
    {
        if (cart.CustomerId > 0)
        {
            Console.WriteLine(cart);

            var customer = _context.Customers
                .Include(c => c.User)
                .FirstOrDefault(c => c.CustomerId == cart.CustomerId);

            if (customer == null)
            {
                return null;
            }

            cart.CustomerId = customer.CustomerId;
            cart.Customer = customer;
        }

        _context.Carts.Add(cart);
        _context.SaveChanges();
        return cart;
    }

    // public Cart updateCart(Cart updatedCart)
    // {
    //     var existingCart = _context.Carts.Find(updatedCart.CartId);

    //     if (existingCart != null)
    //     {
    //         existingCart.Gifts = updatedCart.Gifts;
    //         existingCart.CustomerId = updatedCart.CustomerId;

    //         _context.SaveChanges();

    //         return existingCart;
    //     }

    //     return null;
    // }
public Cart updateCart(Cart updatedCart)
{
    var existingCart = _context.Carts
        .Include(c => c.Gifts) // Include the Gifts collection
        .FirstOrDefault(c => c.CartId == updatedCart.CartId);

    if (existingCart != null)
    {
        // Update individual properties of Cart
        existingCart.CustomerId = updatedCart.CustomerId;

        // Clear existing gifts and add the updated ones
        existingCart.Gifts.Clear();
        existingCart.Gifts.AddRange(updatedCart.Gifts);

        _context.SaveChanges();

        return existingCart;
    }

    return null;
}

    public Cart getCartByCustomerId(long customerId)
    {
        // return _context.Carts.FirstOrDefault(c => c.CustomerId == customerId);
        return _context.Carts
        .Include(c => c.Customer)  // Include the associated customer details
        .Include(c => c.Gifts)     // Include the associated gifts
        .FirstOrDefault(c => c.CustomerId == customerId);
    }

    public List<Gift> getAllGiftsByCustomerId(long customerId)
    {
        var cart = getCartByCustomerId(customerId);

        if (cart != null)
        {
            if (cart.Gifts != null)
            {
                return cart.Gifts.ToList();
            }
            else
            {
                Console.WriteLine("Cart has no associated gifts.");
            }
        }
        else
        {
            Console.WriteLine($"Cart not found for customer ID: {customerId}");
        }

        return new List<Gift>();
    }
}