using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public class GiftServiceImpl : GiftService
    {
        private readonly GiftRepository _giftRepository;

        public GiftServiceImpl(GiftRepository giftRepository)
        {
            _giftRepository = giftRepository;
        }

        public Gift addGift(Gift gift)
        {
            return _giftRepository.addGift(gift);
        }

        public List<Gift> viewAllGifts()
        {
            return _giftRepository.viewAllGifts();
        }

        public Gift updateGift(long giftId, Gift updatedGift)
        {
            return _giftRepository.updateGift(giftId, updatedGift);
        }

        public Gift deleteGift(long giftId)
        {
            return _giftRepository.deleteGift(giftId);
        }
    }
}