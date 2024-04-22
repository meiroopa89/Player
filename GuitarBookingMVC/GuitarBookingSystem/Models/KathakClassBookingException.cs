using System;

namespace GuitarBookingSystem.Models
{

    public class GuitarClassBookingException : Exception
    {
        public GuitarClassBookingException(string message) : base(message)
        {
        }
    }
}
