using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
public class Book
{
    [Key]
    public int bookId { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string title { get; set; }
    
    [Required(ErrorMessage = "Author is required")]
    public string author { get; set; }
    
    [Required(ErrorMessage = "Genre is required")]
    public string genre { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
    public decimal price { get; set; }
    
    [Required(ErrorMessage = "ISBN is required")]
    public string isbn { get; set; }
}
}
