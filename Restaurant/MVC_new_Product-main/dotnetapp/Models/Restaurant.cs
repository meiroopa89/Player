using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } // Additional property for describing the restaurant

        [Required(ErrorMessage = "Cuisine type is required")]
        public string CuisineType { get; set; } // Property to specify the type of cuisine served

        [Required(ErrorMessage = "Opening time is required")]
        public TimeSpan? OpeningTime { get; set; } // Property to store the opening time

        [Required(ErrorMessage = "Closing time is required")]
        public TimeSpan? ClosingTime { get; set; } // Property to store the closing time
    }
}
