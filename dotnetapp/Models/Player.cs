using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Player
    {
        [Key]
        public int playerId { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "Position is required")]
        public string position { get; set; }
        
        [Required(ErrorMessage = "Number is required")]
        [Range(0, 99, ErrorMessage = "Number must be between 0 and 99")]
        public int number { get; set; }
        
        [Required(ErrorMessage = "Age is required")]
        [Range(16, 50, ErrorMessage = "Age must be between 16 and 50")]
        public int age { get; set; }
        
        [Required(ErrorMessage = "Nationality is required")]
        public string nationality { get; set; }
    }
}
