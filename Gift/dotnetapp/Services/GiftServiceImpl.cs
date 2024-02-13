// using System.Collections.Generic;
// using dotnetapp.Models;

// namespace dotnetapp.Services
// {
//     public class GiftServiceImpl : GiftService
//     {
//         private readonly GiftRepository _giftRepository;

//         public GiftServiceImpl(GiftRepository giftRepository)
//         {
//             _giftRepository = giftRepository;
//         }

//         public Gift addGift(Gift gift)
//         {
//             return _giftRepository.addGift(gift);
//         }

//         // Corrected method signature without parameters
//         public List<Gift> viewAllGifts()
//         {
//             // Update to use the modified repository method
//             return _giftRepository.viewAllGifts();
//         }

//         public Gift updateGift(long giftId, Gift updatedGift)
//         {
//             return _giftRepository.updateGift(giftId, updatedGift);
//         }

//         public Gift deleteGift(long giftId)
//         {
//             return _giftRepository.deleteGift(giftId);
//         }

//         public Gift getGiftById(long giftId)
//         {
//             var gift = _giftRepository.viewAllGifts()
//                                     .FirstOrDefault(c => c.GiftId == giftId);
//             return gift;
//         }

//     }
// }
// GiftServiceImpl.cs
using System.Collections.Generic;
using dotnetapp.Models;
using dotnetapp.Repositories;
using dotnetapp.Services;

namespace dotnetapp.Services
{
    public class GiftServiceImpl : GiftService
    {
        private readonly GiftRepository _giftRepository;
        private readonly CartService _cartService;

        public GiftServiceImpl(GiftRepository giftRepository, CartService cartService)
        {
            _giftRepository = giftRepository;
            _cartService = cartService;
        }

        public Gift addGift(Gift gift)
        {
            return _giftRepository.addGift(gift);
        }

        public List<Gift> viewAllGifts(long? cartId = null)
        {
            if (cartId.HasValue)
            {
                // If cartId is provided, fetch gifts inside the specified cart
                var giftsInCart = _cartService.viewAllGifts(cartId.Value);
                return giftsInCart;
            }
            else
            {
                // If no cartId is provided, fetch all gifts
                return _giftRepository.viewAllGifts();
            }
        }

        // public Gift updateGift(long cartId, long giftId, Gift updatedGift)
        // {
        //     return _giftRepository.updateGift(cartId, giftId, updatedGift);
        // }

        public Gift updateGift(long id, Gift updatedGift)
        {
            // Ensure the gift belongs to the specified cart before updating
            var giftInCart = _cartService.getGiftById(giftId);

            if (giftInCart != null)
            {
                // Perform the update on the gift
                return _giftRepository.updateGift(giftId, updatedGift);
            }

            return null; // Gift not found or not associated with the specified cart
        }


        public Gift deleteGift(long giftId)
        {
            return _giftRepository.deleteGift(giftId);
        }

        public Gift getGiftById(long giftId)
        {
            var gift = _giftRepository.IncludeCart()
                                      .FirstOrDefault(c => c.GiftId == giftId);

            return gift;
        }
    }
}
