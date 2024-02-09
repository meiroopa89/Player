using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Customer
{
    public long CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Address { get; set; }
    public User User { get; set; }
}
}