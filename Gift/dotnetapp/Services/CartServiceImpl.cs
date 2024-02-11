using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
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
    }
}
