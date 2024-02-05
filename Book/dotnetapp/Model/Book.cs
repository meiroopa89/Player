using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Model
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Please provide the publisher's name")]
        public string Publisher { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Number of Pages is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid number of pages")]
        public int NumberOfPages { get; set; }
    }
}
