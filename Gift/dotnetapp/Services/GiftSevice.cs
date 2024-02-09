// Services/GiftService.cs
using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface GiftService
    {
        Gift addGift(Gift gift);
        List<Gift> viewAllGifts();
        Gift updateGift(long giftId, Gift gift);
        Gift deleteGift(long giftId);
    }
}

