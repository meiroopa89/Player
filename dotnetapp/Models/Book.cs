using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Book
{
    [Key]
    public int BookId { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "Author is required")]
    public string Author { get; set; }
    
    [Required(ErrorMessage = "Genre is required")]
    public string Genre { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "ISBN is required")]
    public string ISBN { get; set; }
}
}
