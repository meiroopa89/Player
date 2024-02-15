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

    // public Cart addCart(Cart cart)
    // {
    //     if (cart.CustomerId > 0)
    //     {
    //         Console.WriteLine(cart);

    //         var customer = _context.Customers
    //             .Include(c => c.User)
    //             .FirstOrDefault(c => c.CustomerId == cart.CustomerId);

    //         if (customer == null)
    //         {
    //             return null;
    //         }

    //         cart.CustomerId = customer.CustomerId;
    //         cart.Customer = customer;
    //     }

    //     _context.Carts.Add(cart);
    //     _context.SaveChanges();
    //     return cart;
    // }

//     public Cart AddCart(Cart cart, int giftId, int customerId)
// {
//     if (customerId > 0)
//     {
//         Console.WriteLine(cart);

//         var customer = _context.Customers
//             .Include(c => c.User)
//             .FirstOrDefault(c => c.CustomerId == customerId);

//         if (customer == null)
//         {
//             return null; // Or handle the situation where the customer is not found
//         }

//         cart.CustomerId = customer.CustomerId;
//         cart.Customer = customer;
//     }

//     // Now, let's associate the gift with the cart
//     var gift = _context.Gifts.FirstOrDefault(g => g.GiftId == giftId);

//     if (gift == null)
//     {
//         return null; // Or handle the situation where the gift is not found
//     }

//     // Assuming you have a navigation property in your Cart model to represent the gifts in the cart
//     cart.Gifts.Add(gift);

//     _context.Carts.Add(cart);
//     _context.SaveChanges();
    
//     return cart;
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

        // Update existing gifts based on the updated ones
        foreach (var updatedGift in updatedCart.Gifts)
        {
            var existingGift = existingCart.Gifts.FirstOrDefault(g => g.GiftId == updatedGift.GiftId);

            if (existingGift != null)
            {
                existingGift.GiftType = updatedGift.GiftType;
                existingGift.GiftImageUrl = updatedGift.GiftImageUrl;
                existingGift.GiftDetails = updatedGift.GiftDetails;
                existingGift.GiftPrice = updatedGift.GiftPrice;
                existingGift.Quantity = updatedGift.Quantity;
            }
            else
            {
                // Handle case where the gift is not found in the existingCart
                // You may choose to add it or skip it depending on your requirements
            }
        }

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