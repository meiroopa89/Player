using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Gift
    {
        [Key]
        public long GiftId { get; set; }
        public string GiftType { get; set; }
        public string GiftImageUrl { get; set; }
        public string GiftDetails { get; set; }
        public double GiftPrice { get; set; }
        public int Quantity { get; set; }
        public long? CartId { get; set; } // Foreign key
        public Cart? Cart { get; set; }
        // public long? OrdersId { get; set; } // Foreign key
        // public Orders? Orders { get; set; }
    }
}