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
        _context.Carts.Add(cart);
        _context.SaveChanges();
        return cart;
    }

    public Cart updateCart(Cart updatedCart)
    {
        var existingCart = _context.Carts.Find(updatedCart.CartId);

        if (existingCart != null)
        {
            existingCart.Gifts = updatedCart.Gifts;
            existingCart.CustomerId = updatedCart.CustomerId;

            _context.SaveChanges();

            return existingCart;
        }

        return null;
    }

    public Cart getCartByCustomerId(long customerId)
    {
        return _context.Carts.FirstOrDefault(c => c.CustomerId == customerId);
    }

}




