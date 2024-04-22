using System;

namespace KathakBookingSystem.Models
{

    public class KathakClassBookingException : Exception
    {
        public KathakClassBookingException(string message) : base(message)
        {
        }
    }
}
