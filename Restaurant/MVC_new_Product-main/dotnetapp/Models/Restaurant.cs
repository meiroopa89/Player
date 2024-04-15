using System;

namespace dotnetapp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; } // Additional property for describing the restaurant
        public string CuisineType { get; set; } // Property to specify the type of cuisine served
        public TimeSpan OpeningTime { get; set; } // Property to store the opening time
        public TimeSpan ClosingTime { get; set; } // Property to store the closing time
    }
}
