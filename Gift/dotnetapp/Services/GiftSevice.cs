// Services/GiftService.cs
using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface GiftService
    {
        Gift addGift(Gift gift);
        List<Gift> viewAllGifts(long? cartId = null);
        Gift updateGift(long cartId, long giftId, Gift updatedGift);
        Gift deleteGift(long giftId);


    }
}

