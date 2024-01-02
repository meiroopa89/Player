using System;

namespace dotnetapp.Models
{
public class SlotBookingException : Exception
{
    public SlotBookingException(string message) : base(message)
    {
    }
}
}