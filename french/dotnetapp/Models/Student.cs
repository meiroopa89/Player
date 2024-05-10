using System;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public int BatchID { get; set; }
        
        public Batch? Batch { get; set; }
    }
}
