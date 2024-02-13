// Services/CartService.cs
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface CartService
    {
        Cart addCart(Cart cart);
        // Cart addCartWithCustomerId(long customerId, Cart cart);
        Cart updateCart(Cart updatedCart);
        Cart getCustomerById(long customerId);
        // IQueryable<Cart> IncludeUserAndGifts(long customerId);
    }
}
