// // Repositories/CartRepository.cs
// using System.Collections.Generic;
// using dotnetapp.Models;

// public class CartRepository
// {
//     private readonly List<Cart> _carts = new List<Cart>();
//     private long _nextCartId = 1;

//     public Cart addCart(Cart cart)
//     {
//         cart.CartId = _nextCartId++;
//         _carts.Add(cart);
//         return cart;
//     }

//     public Cart updateCart(Cart updatedCart)
//     {
//         var existingCart = _carts.Find(c => c.CartId == updatedCart.CartId);

//         if (existingCart != null)
//         {
//             // Update properties of existing cart
//             existingCart.Gifts = updatedCart.Gifts;
//             existingCart.CustomerId = updatedCart.CustomerId;
//             // Add any other properties to update

//             return existingCart;
//         }

//         return null; // Cart not found
//     }

//     public Cart getCartByCustomerId(long customerId)
//     {
//         return _carts.Find(c => c.CustomerId == customerId);
//     }
// }
