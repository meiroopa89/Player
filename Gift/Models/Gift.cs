using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Gift
{
    public long GiftId { get; set; }
    public string GiftType { get; set; }
    public string GiftImageUrl { get; set; }
    public string GiftDetails { get; set; }
    public double GiftPrice { get; set; }
    public int Quantity { get; set; }
    public Cart Cart { get; set; }
    public Orders Orders { get; set; }
}
}