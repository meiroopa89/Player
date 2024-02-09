using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;
using Microsoft.EntityFrameworkCore;

public class GiftRepository
{
    private readonly ApplicationDbContext _context;

    public GiftRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Gift AddGift(Gift gift)
    {
        _context.Gifts.Add(gift);
        _context.SaveChanges();
        return gift;
    }

    public List<Gift> GetAllGifts()
    {
        return _context.Gifts.ToList();
    }

    public Gift EditGift(long giftId, Gift updatedGift)
    {
        var existingGift = _context.Gifts.FirstOrDefault(g => g.GiftId == giftId);

        if (existingGift != null)
        {
            // Update properties of existing gift
            existingGift.GiftType = updatedGift.GiftType;
            existingGift.GiftImageUrl = updatedGift.GiftImageUrl;
            existingGift.GiftDetails = updatedGift.GiftDetails;
            existingGift.GiftPrice = updatedGift.GiftPrice;
            existingGift.Quantity = updatedGift.Quantity;
            // Add any other properties to update

            _context.SaveChanges();
            return existingGift;
        }

        return null; // Gift not found
    }

    public Gift DeleteGift(long giftId)
    {
        var giftToRemove = _context.Gifts.FirstOrDefault(g => g.GiftId == giftId);

        if (giftToRemove != null)
        {
            _context.Gifts.Remove(giftToRemove);
            _context.SaveChanges();
            return giftToRemove;
        }

        return null; // Gift not found
    }
}
