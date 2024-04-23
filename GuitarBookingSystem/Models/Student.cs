using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuitarBookingSystem.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public int ClassID { get; set; }

        public Class? Class { get; set; }
    }
}
