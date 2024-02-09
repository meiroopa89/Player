// Services/GiftService.cs
using System.Collections.Generic;
using dotnetapp.Models;

using namespace.Services
{
    public interface GiftService
    {
        Gift AddGift(Gift gift);
        List<Gift> GetAllGifts();
        Gift EditGift(long giftId, Gift updatedGift);
        Gift DeleteGift(long giftId);
    }
}

