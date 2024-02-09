using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Orders
    {
        [Key]
        public long OrderId { get; set; }
        public double OrderPrice { get; set; }
        public int Quantity { get; set; }
        public List<Gift> Gifts { get; set; }
        public long CustomerId { get; set; } // Foreign key
        public Customer Customer { get; set; }
    }
}