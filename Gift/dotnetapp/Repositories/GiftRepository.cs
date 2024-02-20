//new
using System;
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

    // public Gift addGift(Gift gift)
    // {
    //     // gift.CartId = ;
    //     _context.Gifts.Add(gift);
    //     _context.SaveChanges();
    //     return gift;
    // }

        public Gift AddGift(Gift gift)
{
    // Check if the GiftType already exists in the database
    if (_context.Gifts.Any(g => g.GiftType == gift.GiftType))
    {
        // GiftType already exists, throw an exception or handle accordingly
        throw new InvalidOperationException("Gift with the same GiftType already exists.");
    }

    // GiftType is unique, add the Gift to the database
    _context.Gifts.Add(gift);
    _context.SaveChanges();

    return gift;
}



    public List<Gift> getAllGifts()
    {
        Console.WriteLine("gift repo");
        return _context.Gifts.ToList();
    }


    public Gift editGift(long giftId, Gift updatedGift)
{
    var existingGift = _context.Gifts
        .Include(g => g.Cart) // Include the associated Cart
        .FirstOrDefault(g => g.GiftId == giftId);

    if (existingGift != null)
    {
        existingGift.GiftType = updatedGift.GiftType;
        existingGift.GiftImageUrl = updatedGift.GiftImageUrl;
        existingGift.GiftDetails = updatedGift.GiftDetails;
        existingGift.GiftPrice = updatedGift.GiftPrice;
        existingGift.Quantity = updatedGift.Quantity;

        // If the input provides a new CartId, update it
        if (updatedGift.CartId != 0)
        {
            existingGift.CartId = updatedGift.CartId;
        }
        else
        {
            // Fetch the latest CartId directly from the Cart table
            var latestCartId = _context.Carts
                .Where(c => c.CustomerId == existingGift.Cart.CustomerId)
                .OrderByDescending(c => c.CartId)
                .Select(c => c.CartId)
                .FirstOrDefault();

            // Update the CartId in the existingGift
            existingGift.CartId = latestCartId;
        }

        _context.SaveChanges();
        return existingGift;
    }

    return null; // Gift not found
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

        return null; // Gift not found
    }
}
