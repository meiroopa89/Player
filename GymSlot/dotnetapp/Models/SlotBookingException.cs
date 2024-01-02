using System;

namespace GymSlot.dotnetapp.Exceptions
{
public class SlotBookingException : Exception
{
    public SlotBookingException(string message) : base(message)
    {
    }
}
}