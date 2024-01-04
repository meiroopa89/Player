using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Model { get; set; }
        public DateTime Date { get; set; }
        public string Color { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}