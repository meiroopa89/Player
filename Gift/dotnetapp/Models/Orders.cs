using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Orders
{
    public long OrderId { get; set; }
    public double OrderPrice { get; set; }
    public int Quantity { get; set; }
    public List<Gift> Gifts { get; set; }
    public Customer Customer { get; set; }
}
}