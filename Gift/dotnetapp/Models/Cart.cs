using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Cart
    {
        public long CartId { get; set; }
        public List<Gift> Gifts { get; set; }
        public long CustomerId { get; set; } // Foreign key
        public Customer Customer { get; set; }
        public double TotalAmount { get; set; }
    }
}