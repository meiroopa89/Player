using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;

public class GiftRepository
{
    private readonly List<Gift> _gifts = new List<Gift>();
    private long _nextGiftId = 1;

    public Gift addGift(Gift gift)
    {
        gift.GiftId = _nextGiftId++;
        _gifts.Add(gift);
        return gift;
    }

    public List<Gift> viewAllGifts()
    {
        return _gifts.ToList();
    }

    public Gift updateGift(long giftId, Gift updatedGift)
    {
        var existingGift = _gifts.FirstOrDefault(g => g.GiftId == giftId);

        if (existingGift != null)
        {
            existingGift.GiftType = updatedGift.GiftType;
            existingGift.GiftImageUrl = updatedGift.GiftImageUrl;
            existingGift.GiftDetails = updatedGift.GiftDetails;
            existingGift.GiftPrice = updatedGift.GiftPrice;
            existingGift.Quantity = updatedGift.Quantity;
            // Add any other properties to update

            return existingGift;
        }

        return null;
    }

    public Gift deleteGift(long giftId)
    {
        var giftToRemove = _gifts.FirstOrDefault(g => g.GiftId == giftId);

        if (giftToRemove != null)
        {
            _gifts.Remove(giftToRemove);
            return giftToRemove;
        }

        return null;
    }
}
