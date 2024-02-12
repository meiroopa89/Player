using System.Collections.Generic;
using System.Linq;
using dotnetapp.Models;
using dotnetapp.Data;
using Microsoft.EntityFrameworkCore;
public class GiftRepository
{
    private readonly ApplicationDbContext _context;

    public GiftRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Gift addGift(Gift gift)
    {
        _context.Gifts.Add(gift);
        _context.SaveChanges();
        return gift;
    }

    public List<Gift> viewAllGifts()
    {
        // return _context.Gifts.ToList();
        return _context.Gifts
        .Include(g => g.Cart)  // Include the Cart navigation property
        .ToList();
    }

    public Gift updateGift(long giftId, Gift updatedGift)
    {
        var existingGift = _context.Gifts.Find(giftId);

        if (existingGift != null)
        {
            existingGift.GiftType = updatedGift.GiftType;
            existingGift.GiftImageUrl = updatedGift.GiftImageUrl;
            existingGift.GiftDetails = updatedGift.GiftDetails;
            existingGift.GiftPrice = updatedGift.GiftPrice;
            existingGift.Quantity = updatedGift.Quantity;
            // Add any other properties to update

            _context.SaveChanges();
            return existingGift;
        }

        return null;
    }

    public Gift deleteGift(long giftId)
    {
        var giftToRemove = _context.Gifts.Find(giftId);

        if (giftToRemove != null)
        {
            _context.Gifts.Remove(giftToRemove);
            _context.SaveChanges();
            return giftToRemove;
        }

        return null;
    }
}
