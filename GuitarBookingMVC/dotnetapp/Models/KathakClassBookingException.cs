using System;

namespace dotnetapp.Models
{

    public class KathakClassBookingException : Exception
    {
        public KathakClassBookingException(string message) : base(message)
        {
        }
    }
}
