// Services/GiftService.cs
using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface GiftService
    {
        Gift AddGift(Gift gift);
        List<Gift> GetAllGifts();
        Gift EditGift(long giftId, Gift updatedGift);
        Gift DeleteGift(long giftId);
    }
}

